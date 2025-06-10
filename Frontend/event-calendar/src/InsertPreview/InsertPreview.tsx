import React, { memo } from "react";

const InsertPreview: React.FC = memo(() => {
  return (
    <div
      className="my-2 rounded-2"
      style={{
        border: "3px dotted #0d6efd",
        backgroundColor: "rgba(112, 169, 255, 0.3)",
        borderRadius: "4px",
        height: "60px",
        opacity: "0.3",
      }}
    ></div>
  );
});

export default InsertPreview;
