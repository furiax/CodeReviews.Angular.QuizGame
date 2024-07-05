export interface QuestionModel {
    questionId : string;
    questionToAsk : string;
    correctAnswer : string;
    option1? : string | null;
    option2? : string | null;
    option3? : string | null;
    option4? : string | null;
    quizId: string;
}
