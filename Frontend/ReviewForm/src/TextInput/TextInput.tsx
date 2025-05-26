import styles from "./TextInput.module.css";

interface InputProps {
  label: string;
  type: string;
  placeholder: string;
  name: string;
  maxLength: number;
  minLength: number;
  onChange: (value: string) => void;
  required?: boolean;
}

const Input: React.FC<InputProps> = ({
  label,
  type,
  placeholder,
  name,
  minLength,
  maxLength,
  onChange,
  required = false,
}) => {
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    onChange(e.target.value);
  };

  return (
    <div className={styles.inputContainer}>
      <input
        placeholder={placeholder}
        type={type}
        name={name}
        minLength={minLength}
        maxLength={maxLength}
        required={required}
        onChange={handleChange}
      />
      <span>{label}</span>
    </div>
  );
};

export default Input;
