import { HttpClient } from '@angular/common/http';
import { IQuiz } from './../../models/iquz';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent implements OnInit {
  // @Input("quiz") quiz: IQuiz = <IQuiz>{};
  public quiz: IQuiz = <IQuiz>{};

  constructor(
    private activateRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {
    var id: number = +this.activateRoute.snapshot.params['id'];
    console.log('Id: ' + id);

    if (id) {
      var url = 'http://localhost:8088/api/Quiz/' + id;
      this.http.get<IQuiz>(url).subscribe(
        result => {
          this.quiz = result;
          console.log(this.quiz);
        },
        error => {
          console.error(error);
        }
      );
    } else {
      console.log('Nieprawidłowe id');
      this.router.navigate(['home']);
    }
  }


  ngOnInit(): void {
  }

}
