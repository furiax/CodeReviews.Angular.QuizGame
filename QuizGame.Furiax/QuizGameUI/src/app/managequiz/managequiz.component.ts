import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { QuizgameserviceService } from '../quizgameservice.service';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { QuizModel } from '../quiz-model';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-managequiz',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, HttpClientModule],
  templateUrl: './managequiz.component.html',
  styleUrl: './managequiz.component.scss'
})
export class ManagequizComponent implements AfterViewInit {
  displayedColumns: string[] = ['id', 'name'];
  dataSource : MatTableDataSource<QuizModel> = new MatTableDataSource<QuizModel>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  constructor(private quizService: QuizgameserviceService){}

  ngOnInit(): void{
    this.getAllQuizzes();
  }

  getAllQuizzes(){
    this.quizService.getAllQuizzes()
    .subscribe({
      next: (response) => {
        this.dataSource = new MatTableDataSource(response);
        this.dataSource.paginator = this.paginator;
      },
      error: (err) => {alert("An error occurred while fetching quizzes" + err);}
    });
  }
}
