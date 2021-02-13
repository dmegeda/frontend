import { Answer } from './answer';
export interface Question {
  id: number;
  isDeleted: boolean;
  text: string;
  answers: Answer[];
  answerId: number;
}
