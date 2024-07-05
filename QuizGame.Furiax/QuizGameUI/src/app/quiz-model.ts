import { QuestionModel } from "./question-model";
import { GameModel } from "./game-model";

export interface QuizModel {
    quizId: string;
    quizName: string;
    questions?: QuestionModel[];
    games?: GameModel[];

}
