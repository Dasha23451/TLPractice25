import React, { useState, useRef, useCallback, useEffect } from "react";
import WeekColumn from "../WeekColumn/WeekColumn";
import DraggedCard from "../DraggedCard/DraggedCard";
import styles from "./WeekBoard.module.css";

type Task = {
  id: string;
  text: string;
  order: number;
};

type WeekColumnData = {
  id: string;
  title: string;
  tasks: Task[];
};

type DragState = {
  taskId: string;
  sourceWeekId: string;
  sourceIndex: number;
  task: Task;
  offsetX: number;
  offsetY: number;
};

const WeekBoard = () => {
  const [newTaskText, setNewTaskText] = useState("");
  const [weeks, setWeeks] = useState<WeekColumnData[]>([
    {
      id: "week1",
      title: "Неделя 1",
      tasks: [
        { id: "task1", text: "Wash shirts", order: 1 },
        { id: "task2", text: "Go play football", order: 2 },
        { id: "task3", text: "Do assignment", order: 3 },
        { id: "task4", text: "Go on a date", order: 4 },
        { id: "task5", text: "Read a book", order: 5 },
      ],
    },
    { id: "week2", title: "Неделя 2", tasks: [] },
    { id: "week3", title: "Неделя 3", tasks: [] },
    { id: "week4", title: "Неделя 4", tasks: [] },
  ]);

  const addTask = () => {
    if (!newTaskText.trim()) return;

    const newTask: Task = {
      id: `task${Date.now()}`,
      text: newTaskText,
      order: weeks[0].tasks.length + 1,
    };

    setWeeks((prevWeeks) => {
      const newWeeks = [...prevWeeks];
      newWeeks[0] = {
        ...newWeeks[0],
        tasks: [...newWeeks[0].tasks, newTask],
      };
      return newWeeks;
    });

    setNewTaskText("");
  };

  const [dragState, setDragState] = useState<DragState | null>(null);
  const [currentPosition, setCurrentPosition] = useState({ x: 0, y: 0 });
  const [dropTarget, setDropTarget] = useState<{
    weekId: string;
    index: number;
  } | null>(null);

  const weekRefs = useRef<{ [key: string]: HTMLDivElement | null }>({});
  const taskRefs = useRef<{ [key: string]: HTMLDivElement | null }>({});

  const handleDragStart = useCallback(
    (
      weekId: string,
      taskId: string,
      clientX: number,
      clientY: number,
      offsetX: number,
      offsetY: number
    ) => {
      const week = weeks.find((w) => w.id === weekId);
      if (!week) return;

      const taskIndex = week.tasks.findIndex((t) => t.id === taskId);
      if (taskIndex === -1) return;

      setDragState({
        taskId,
        sourceWeekId: weekId,
        sourceIndex: taskIndex,
        task: week.tasks[taskIndex],
        offsetX,
        offsetY,
      });

      setCurrentPosition({ x: clientX - offsetX, y: clientY - offsetY });
    },
    [weeks]
  );

  const handleMouseMove = useCallback(
    (e: MouseEvent) => {
      if (!dragState) return;

      setCurrentPosition({
        x: e.clientX - dragState.offsetX,
        y: e.clientY - dragState.offsetY,
      });

      let hoveredWeekId: string | null = null;
      weeks.forEach((week) => {
        const ref = weekRefs.current[week.id];
        if (!ref) return;
        const rect = ref.getBoundingClientRect();
        if (
          e.clientX >= rect.left &&
          e.clientX <= rect.right &&
          e.clientY >= rect.top &&
          e.clientY <= rect.bottom
        ) {
          hoveredWeekId = week.id;
        }
      });

      if (!hoveredWeekId) {
        setDropTarget(null);
        return;
      }

      const hoveredWeek = weeks.find((w) => w.id === hoveredWeekId)!;
      let dropIndex = hoveredWeek.tasks.length;

      for (let i = 0; i < hoveredWeek.tasks.length; i++) {
        const task = hoveredWeek.tasks[i];
        if (
          hoveredWeekId === dragState.sourceWeekId &&
          task.id === dragState.taskId
        )
          continue;

        const taskElement = taskRefs.current[task.id];
        if (!taskElement) continue;

        const rect = taskElement.getBoundingClientRect();
        if (e.clientY < rect.top + rect.height / 2) {
          dropIndex = i;
          break;
        }
      }

      if (
        hoveredWeekId === dragState.sourceWeekId &&
        (dropIndex === dragState.sourceIndex ||
          dropIndex === dragState.sourceIndex + 1)
      ) {
        setDropTarget(null);
        return;
      }

      setDropTarget({ weekId: hoveredWeekId, index: dropIndex });
    },
    [dragState, weeks]
  );

  const handleMouseUp = useCallback(() => {
    if (!dragState || !dropTarget) {
      setDragState(null);
      setDropTarget(null);
      return;
    }

    setWeeks((prevWeeks) => {
      const newWeeks = prevWeeks.map((w) => ({ ...w, tasks: [...w.tasks] }));
      const sourceWeek = newWeeks.find((w) => w.id === dragState.sourceWeekId)!;
      const [movedTask] = sourceWeek.tasks.splice(dragState.sourceIndex, 1);

      const targetWeek = newWeeks.find((w) => w.id === dropTarget.weekId)!;
      let insertIndex = dropTarget.index;

      if (
        targetWeek.id === sourceWeek.id &&
        dragState.sourceIndex < insertIndex
      ) {
        insertIndex--;
      }

      targetWeek.tasks.splice(insertIndex, 0, movedTask);

      newWeeks.forEach((week) => {
        week.tasks.forEach((task, idx) => {
          task.order = idx + 1;
        });
      });

      return newWeeks;
    });

    setDragState(null);
    setDropTarget(null);
  }, [dragState, dropTarget]);

  useEffect(() => {
    if (dragState) {
      window.addEventListener("mousemove", handleMouseMove);
      window.addEventListener("mouseup", handleMouseUp);
    }

    return () => {
      window.removeEventListener("mousemove", handleMouseMove);
      window.removeEventListener("mouseup", handleMouseUp);
    };
  }, [dragState, handleMouseMove, handleMouseUp]);

  return (
    <div className={styles.boardContainer}>
      <div className={styles.weeksRow}>
        {weeks.map((week) => (
          <WeekColumn
            key={week.id}
            week={week}
            onTaskDragStart={handleDragStart}
            dropIndex={dropTarget?.weekId === week.id ? dropTarget.index : null}
            draggingTaskId={dragState?.taskId || null}
            setWeekRef={(el) => (weekRefs.current[week.id] = el)}
            setTaskRef={(id, el) => (taskRefs.current[id] = el)}
          />
        ))}
      </div>

      {dragState && (
        <DraggedCard
          x={currentPosition.x}
          y={currentPosition.y}
          task={dragState.task}
        />
      )}
      <div className={styles.taskInput}>
        <input
          type="text"
          value={newTaskText}
          onChange={(e) => setNewTaskText(e.target.value)}
          placeholder="Введите текст задачи"
        />
        <button onClick={addTask}>Добавить задачу</button>
      </div>
    </div>
  );
};

export default WeekBoard;
