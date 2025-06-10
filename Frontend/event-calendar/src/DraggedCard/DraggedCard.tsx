import React, { memo } from "react";
import styles from "./DraggedCard.module.css";

type DraggedCardProps = {
  x: number;
  y: number;
  task: {
    id: string;
    text: string;
    order: number;
  };
};

const DraggedCard: React.FC<DraggedCardProps> = memo(({ x, y, task }) => {
  return (
    <div
      className={styles.draggedCard}
      style={{
        left: x,
        top: y,
      }}
    >
      <div className="task-content">
        <span className="task-order">{task.order}.</span>
        <span className="task-text">{task.text}</span>
      </div>
    </div>
  );
});

export default DraggedCard;
