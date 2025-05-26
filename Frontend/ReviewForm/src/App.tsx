import "./App.css";
import Form from "./Form/Form";
import ReviewsList from "./ReviewList/ReviewList";
import { useReviews } from "./hooks/useReviews";

function App() {
  const { reviews, addReview } = useReviews();

  return (
    <>
      <Form onAddReview={addReview} />
      <ReviewsList reviews={reviews} />
    </>
  );
}

export default App;
