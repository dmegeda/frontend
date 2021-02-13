import { StatisticService } from './../../services/statistic/statistic.service';
import { UserService } from './../../services/user/user.service';
import { Statistic } from './../../interfaces/statistic';
import { Question } from './../../interfaces/question';
import { Test } from './../../interfaces/test';
import { TestService } from './../../services/test/test.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {

  id: number;
  test: Test;
  loaded: boolean;
  isTesting: boolean;
  statistic = {} as Statistic;

  constructor(private testService: TestService, private userService: UserService, private statService: StatisticService,
              activeRoute: ActivatedRoute, private route: Router) {
      const id_parsed = Number.parseInt(activeRoute.snapshot.params["id"]);
      if (isFinite(id_parsed)) {
        this.id = id_parsed;
      }
      else {
        this.route.navigateByUrl('/home');
      }
  }

  ngOnInit(): void {
    this.testService.getTest(this.id).subscribe((data) => {
      if (data !== null) {
        this.test = data;
        this.loaded = true;
        this.statistic.test_Id = data.id;
      }
      else {
        this.route.navigateByUrl('/home');
      }
    });
  }

  goTesting(): void{
    if (localStorage.getItem('token') == null) {
      this.route.navigateByUrl('/login');
    }
    else {
      this.isTesting = true;
    }
  }

  finishTest(): void{
    const correctCount = this.getCorrectAnswersCount();
    const user_id = this.userService.getCurrentUserData().UserID;
    this.statistic = { correctAnswersCount: correctCount, user_Id: user_id, test_Id: this.test.id };
    this.isTesting = false;
    this.statService.createStatistic(this.statistic).subscribe(
      () => {
        this.route.navigate(['statistic']);
      }
    );
  }

  getCorrectAnswersCount(): number{
    let correctAnsw = 0;
    for (const question of this.test.questions) {
      const radios = document.getElementsByTagName("input");
      for (let i = 0; i < radios.length; i++){
        if (radios[i].type === 'radio'
          && radios[i].name === `${question.text}`
          && radios[i].checked === true) {
          const title = radios[i].value;
          if (this.checkIsCorrect(title, question)) {
            correctAnsw++;
          }
        }
      }
    }
    return correctAnsw;
  }

  checkIsCorrect(title: string, question: Question): boolean {
    for (let answer of question.answers) {
      if (answer.text === title
        && answer.id === question.answerId) {
        return true;
      }
    }
    return false;
  }

  convertDateToLocale(date: Date): string {
    date = new Date(date);
    return date.toLocaleDateString();
  }
}
