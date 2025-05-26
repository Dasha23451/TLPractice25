export type Review = {
  id: number;
  userName: string;
  rating: number;
  comment: string;
  date: string;
  avatar: string | null;
};

export type FormState = {
  userName: string;
  avatar: string | ArrayBuffer | null;
  comment: string;
  overallAssessment: number;
  ratings: {
    cleanliness: number;
    service: number;
    speed: number;
    location: number;
    speechCulture: number;
  };
};
