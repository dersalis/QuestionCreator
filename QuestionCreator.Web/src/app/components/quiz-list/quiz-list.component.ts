import { Component, Inject, OnInit } from '@angular/core';
import { IQuiz } from 'src/app/models/iquz';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-quiz-list',
  templateUrl: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.scss']
})
export class QuizListComponent implements OnInit {
  title: string = "";
  selectedQuiz: IQuiz = <IQuiz>{};
  quizzes: IQuiz[] = [];

  constructor(
    private http: HttpClient
  ) {
    this.title = "Najnowsze quizy";
    var url = "http://localhost:8088/api/Quiz/Latest";
    http.get<IQuiz[]>(url).subscribe(
      result => {
        this.quizzes = result;
        console.log(this.quizzes);
      },
      error => {
        console.error(error);
      }
    );
  }

  public onSelect(quiz: IQuiz): void {
    this.selectedQuiz = quiz;
    console.log("Wybrano quiz o id: " + this.selectedQuiz.Id);
  }

  ngOnInit(): void {
  }

}
