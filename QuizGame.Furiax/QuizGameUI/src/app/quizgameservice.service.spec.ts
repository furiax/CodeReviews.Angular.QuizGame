import { TestBed } from '@angular/core/testing';

import { QuizgameserviceService } from './quizgameservice.service';

describe('QuizgameserviceService', () => {
  let service: QuizgameserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QuizgameserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
