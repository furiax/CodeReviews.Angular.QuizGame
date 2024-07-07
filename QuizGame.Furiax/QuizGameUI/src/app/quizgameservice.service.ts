import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { QuizModel } from './quiz-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuizgameserviceService {

  readonly apiUrl = 'https://localhost:7203/api';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private http: HttpClient) { }

  addQuiz(quiz: QuizModel): Observable<QuizModel>{
    return this.http.post<QuizModel>(this.apiUrl + '/quiz', quiz, this.httpOptions)
  }

  getAllQuizzes(): Observable<QuizModel[]>{
    return this.http.get<QuizModel[]>(this.apiUrl + '/quiz');
  }
}
