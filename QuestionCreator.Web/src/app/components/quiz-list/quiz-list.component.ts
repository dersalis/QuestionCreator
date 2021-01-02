import { IQuiz } from './../../models/iquz';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router';

@Component({
  selector: 'app-quiz-list',
  templateUrl: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.scss']
})
export class QuizListComponent implements OnInit {
  @Input('listtype') listtype: string = '';
  public title: string = "";
  public selectedQuiz: IQuiz = <IQuiz>{};
  public quizzes: IQuiz[] = [];

  constructor(
    private http: HttpClient,
    private router: Router
  ) {}

  public onSelect(quiz: IQuiz): void {
    this.selectedQuiz = quiz;
    console.log("Wybrano quiz o id: " + this.selectedQuiz.Id);
    this.router.navigate(['quiz', this.selectedQuiz.Id]);
  }

  ngOnInit(): void {
    var url = "http://localhost:8088/api/Quiz/Latest";
    switch (this.listtype) {
      case 'latest':
        this.title = "Najnowsze quizy";
        url = "http://localhost:8088/api/Quiz/Latest";
        break;
      case 'byTitle':
        this.title = "Quizy alfabetycznie";
        url = "http://localhost:8088/api/Quiz/ByTitle";
        break;
      case 'random':
        this.title = "Losowe quizy";
        url = "http://localhost:8088/api/Quiz/Random";
        break;
    }


    this.http.get<IQuiz[]>(url).subscribe(
      result => {
        this.quizzes = result;
        console.log(this.quizzes);
      },
      error => {
        console.error(error);
      }
    );
  }

}
