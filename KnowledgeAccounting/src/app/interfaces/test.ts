import { Theme } from './theme';
import { Question } from './question';

export interface Test {
  id: number;
  isDeleted: boolean;
  title: string;
  description: string;
  maxRate: number;
  minRatingForPass: number;
  startDate: Date;
  deadline: Date;
  questions: Question[];
  theme: Theme;
}
