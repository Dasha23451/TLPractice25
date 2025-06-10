import React, { memo } from "react";
import TaskCard from "../TaskCard/TaskCard";
import DropIndicator from "../DropIndicator/DropIndicator";
import styles from "./WeekColumn.module.css";

type Task = {
  id: string;
  text: string;
  order: number;
};

type WeekColumnProps = {
  week: {
    id: string;
    title: string;
    tasks: Task[];
  };
  onTaskDragStart: (
    weekId: string,
    taskId: string,
    clientX: number,
    clientY: number,
    offsetX: number,
    offsetY: number
  ) => void;
  dropIndex: number | null;
  draggingTaskId: string | null;
  setWeekRef: (el: HTMLDivElement | null) => void;
  setTaskRef: (id: string, el: HTMLDivElement | null) => void;
};

const WeekColumn: React.FC<WeekColumnProps> = memo(
  ({
    week,
    onTaskDragStart,
    dropIndex,
    draggingTaskId,
    setWeekRef,
    setTaskRef,
  }) => {
    return (
      <div className={styles.weekColumn} ref={setWeekRef}>
        <div className={styles.weekHeader}>
          <h3>{week.title}</h3>
        </div>
        <div className={styles.tasksContainer}>
          {dropIndex === 0 && <DropIndicator />}
          {week.tasks.map((task, index) => (
            <React.Fragment key={task.id}>
              <TaskCard
                task={task}
                weekId={week.id}
                onDragStart={onTaskDragStart}
                isDragging={draggingTaskId === task.id}
                setRef={(el) => setTaskRef(task.id, el)}
              />
              {dropIndex === index + 1 && <DropIndicator />}
            </React.Fragment>
          ))}
        </div>
      </div>
    );
  }
);

export default WeekColumn;
