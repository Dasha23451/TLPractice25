import './ErrorDisplay.css';

interface ErrorDisplayProps {
  error: string;
  onRetry: () => void;
}

const ErrorDisplay = ({ error, onRetry }: ErrorDisplayProps) => {
  return (
    <div className="error-display">
      <h2>COULD NOT GET DATA FROM THE SERVER</h2>
      <p>{error}</p>
      <button onClick={onRetry}>Retry</button>
    </div>
  );
};

export default ErrorDisplay;
