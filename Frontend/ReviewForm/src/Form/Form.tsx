import Slider from "../Slider/Slider";
import Input from "../TextInput/TextInput";
import styles from "./Form.module.css";
import Textarea from "../TextArea/Textarea";
import { useEffect, useRef, useState } from "react";
import type { FormState, Review } from "../types/types";
import { format } from "date-fns";

interface ReviewFormProps {
  onAddReview: (review: Review) => void;
}

const initialFormState: FormState = {
  userName: "",
  avatar: null,
  comment: "",
  overallAssessment: 0,
  ratings: {
    cleanliness: 0,
    service: 0,
    speed: 0,
    location: 0,
    speechCulture: 0,
  },
};

const Form: React.FC<ReviewFormProps> = ({ onAddReview }) => {
  const formRef = useRef<HTMLFormElement>(null);
  const [isFormValid, setIsFormValid] = useState(false);
  const [formState, setFormState] = useState<FormState>(initialFormState);
  const [avatar, setAvatar] = useState<string | null>(null);

  const handleFieldChange = (
    name: keyof FormState | keyof FormState["ratings"],
    value: number | string
  ) => {
    if (name in formState.ratings) {
      setFormState((prev) => ({
        ...prev,
        ratings: { ...prev.ratings, [name]: value },
      }));
    } else {
      setFormState((prev) => ({ ...prev, [name]: value }));
    }
  };

  const handleAvatarChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        if (typeof reader.result === "string") {
          setAvatar(reader.result);
        }
      };
      reader.readAsDataURL(file);
    }
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const rating =
      (formState.ratings.cleanliness +
        formState.ratings.service +
        formState.ratings.speed +
        formState.ratings.location +
        formState.ratings.speechCulture) /
      5;

    const newReview: Review = {
      id: Date.now(),
      userName: formState.userName,
      comment: formState.comment,
      rating: rating,
      date: format(Date.now(), "dd.MM.yyyy"),
      avatar: avatar,
    };

    onAddReview(newReview);
    setFormState(initialFormState);
    setAvatar(null);
    formRef.current?.reset();
  };

  useEffect(() => {
    const isValid =
      formState.userName.trim() !== "" &&
      formState.comment.trim() !== "" &&
      formState.ratings.cleanliness > 0 &&
      formState.ratings.service > 0 &&
      formState.ratings.speed > 0 &&
      formState.ratings.location > 0 &&
      formState.ratings.speechCulture > 0;

    setIsFormValid(isValid);
  }, [formState]);

  return (
    <div className={styles.reviewFormWrapper}>
      <div className={styles.reviewFormContainer}>
        <p className={styles.title}>
          Помогите нам сделать процесс бронирования лучше
        </p>
        <form
          ref={formRef}
          className={styles.reviewForm}
          onSubmit={handleSubmit}
        >
          <Slider
            label="Чистенько"
            value={formState.ratings.cleanliness}
            onChange={(value) => handleFieldChange("cleanliness", value)}
          />
          <Slider
            label="Сервис"
            value={formState.ratings.service}
            onChange={(value) => handleFieldChange("service", value)}
          />
          <Slider
            label="Скорость"
            value={formState.ratings.speed}
            onChange={(value) => handleFieldChange("speed", value)}
          />
          <Slider
            label="Место"
            value={formState.ratings.location}
            onChange={(value) => handleFieldChange("location", value)}
          />
          <Slider
            label="Культура речи"
            value={formState.ratings.speechCulture}
            onChange={(value) => handleFieldChange("speechCulture", value)}
          />
          <label className={styles.fileInputLabel}>
            Выберите файл для аватара
            <input
              type="file"
              accept="image/*"
              onChange={handleAvatarChange}
              className={styles.avatarInput}
            />
          </label>

          {avatar && (
            <img
              src={avatar as string}
              alt="Avatar"
              className={styles.avatarPreview}
            />
          )}
          <Input
            label="*Имя"
            type="text"
            placeholder="Как вас зовут?"
            name="username"
            minLength={1}
            maxLength={30}
            onChange={(value) => handleFieldChange("userName", value)}
          />
          <Textarea
            placeholder="Напишите, что понравилось, что было непонятно"
            onChange={(value) => handleFieldChange("comment", value)}
          />
          <button
            className={`${styles.submitButton} ${
              isFormValid ? styles.submitButtonActive : ""
            }`}
            type="submit"
            disabled={!isFormValid}
          >
            Отправить
          </button>
        </form>
      </div>
    </div>
  );
};

export default Form;
