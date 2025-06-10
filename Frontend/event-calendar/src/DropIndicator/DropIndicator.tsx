import React, { memo } from "react";
import styles from "./DropIndicator.module.css";

const DropIndicator: React.FC = memo(() => {
  return (
    <div className={styles.dropIndicator}>
      <div className={styles.indicatorLine}></div>
    </div>
  );
});

export default DropIndicator;
