import styles from "./ReviewList.module.css";
import type { Review } from "../types/types";

interface ReviewsListProps {
  reviews: Review[];
}

const ReviewsList: React.FC<ReviewsListProps> = ({ reviews }) => {
  return (
    <div className={styles.reviewsListContainer}>
      {reviews.map((review) => (
        <div className={styles.reviewContainer} key={review.id}>
          <img
            className={styles.avatar}
            src={review.avatar ? review.avatar : "../assets/avatar.jpg"}
            alt="Avatar"
          />
          <div className={styles.reviewContent}>
            <div className={styles.reviewInfoContainer}>
              <span className={styles.username}>{review.userName}</span>
              <span className={styles.mark}>{review.rating}/5</span>
            </div>
            <p className={styles.reviewComment}>{review.comment}</p>
          </div>
        </div>
      ))}
    </div>
  );
};

export default ReviewsList;
