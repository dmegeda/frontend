import { questionsCol } from "./questions";
import { themes } from "./themes";

export const tests = [
  {
    id: 1,
    isDeleted: false,
    title: 'Test1',
    description: 'Description1',
    maxRate: 100,
    minRatingForPass: 60,
    startDate: new Date(2021, 1, 1),
    deadline: new Date(2021, 5, 1),
    questions: Array.from(questionsCol),
    theme: themes[0]
  }
];
