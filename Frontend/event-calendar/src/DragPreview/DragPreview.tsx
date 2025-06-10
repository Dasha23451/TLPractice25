import React, { memo } from "react";

type Card = {
  id: string;
  content: string;
};

type DragPreviewProps = {
  x: number;
  y: number;
  card: Card;
};

const DragPreview: React.FC<DragPreviewProps> = memo(({ x, y, card }) => {
  return (
    <div
      className="card"
      style={{
        position: "fixed",
        top: y,
        left: x,
        zIndex: 1000,
        opacity: 0.8,
        pointerEvents: "none",
        border: "1px dashed #0d6efd",
        width: "250px",
      }}
    >
      <div className="card-body">
        <p className="card-text">{card.content}</p>
      </div>
    </div>
  );
});

export default DragPreview;
