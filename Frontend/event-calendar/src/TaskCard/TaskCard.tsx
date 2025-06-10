import React, { memo, useCallback, useRef } from "react";
import styles from "./TaskCard.module.css";

type TaskCardProps = {
  task: {
    id: string;
    text: string;
    order: number;
  };
  weekId: string;
  onDragStart: (
    weekId: string,
    taskId: string,
    clientX: number,
    clientY: number,
    offsetX: number,
    offsetY: number
  ) => void;
  isDragging: boolean;
  setRef: (el: HTMLDivElement | null) => void;
};

const TaskCard: React.FC<TaskCardProps> = memo(
  ({ task, weekId, onDragStart, isDragging, setRef }) => {
    const cardRef = useRef<HTMLDivElement>(null);

    const handleMouseDown = useCallback(
      (e: React.MouseEvent) => {
        if (!cardRef.current) return;
        const rect = cardRef.current.getBoundingClientRect();
        const offsetX = e.clientX - rect.left;
        const offsetY = e.clientY - rect.top;

        onDragStart(weekId, task.id, e.clientX, e.clientY, offsetX, offsetY);
      },
      [onDragStart, task.id, weekId]
    );

    return (
      <div
        ref={(el) => {
          cardRef.current = el;
          setRef(el);
        }}
        className={`${styles.taskCard} ${isDragging ? styles.dragging : ""}`}
        onMouseDown={handleMouseDown}
      >
        <div className={styles.taskContent}>
          <span className={styles.taskOrder}>{task.order}.</span>
          <span className={styles.taskText}>{task.text}</span>
        </div>
      </div>
    );
  }
);

export default TaskCard;
