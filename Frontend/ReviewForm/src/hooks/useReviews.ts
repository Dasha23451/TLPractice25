import { useState } from "react";
import type { Review } from "../types/types";

const STORAGE_KEY = "reviews";

export function useReviews() {
  const [reviews, setReviews] = useState<Review[]>(() => {
    const saved = localStorage.getItem(STORAGE_KEY);
    return saved ? JSON.parse(saved) : [];
  });

  const addReview = (newReview: Review) => {
    setReviews((prev) => {
      const updated = [...prev, newReview];
      localStorage.setItem(STORAGE_KEY, JSON.stringify(updated));
      return updated;
    });
  };

  return { reviews, addReview };
}
