import styles from "./Textarea.module.css";

interface TextareaProps {
  placeholder: string;
  onChange: (value: string) => void;
}

const Textarea: React.FC<TextareaProps> = ({ placeholder, onChange }) => {
  const handleChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    onChange(e.target.value);
  };

  const adjustHeight = (e: React.FormEvent<HTMLTextAreaElement>) => {
    const target = e.currentTarget;
    target.style.height = "auto";
    target.style.height = `${target.scrollHeight}px`;

    if (target.scrollHeight > target.clientHeight) {
      window.scrollBy({ top: target.scrollHeight });
    }
  };

  return (
    <textarea
      className={styles.textarea}
      placeholder={placeholder}
      onChange={handleChange}
      onInput={adjustHeight}
    />
  );
};

export default Textarea;
