import { Router } from '@angular/router';
import { Test } from './../../interfaces/test';
import { TestService } from './../../services/test/test.service';
import { StatisticDetails } from './../../interfaces/statistic-details';
import { Statistic } from './../../interfaces/statistic';
import { UserService } from './../../services/user/user.service';
import { StatisticService } from './../../services/statistic/statistic.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.scss']
})
export class StatisticComponent implements OnInit {

  statistics: StatisticDetails[] = [];
  tests: Test[] = [];

  constructor(private service: StatisticService, private userService: UserService,
              private testService: TestService, private route: Router) { }

  ngOnInit() {
    if (localStorage.getItem('token') == null) {
      this.route.navigateByUrl('/login');
    }
    else {
      const user_id = this.userService.getCurrentUserData().UserID;
      console.log(this.userService.getCurrentUserData());
      this.service.getUserStatistic(user_id).subscribe((data) => {
        this.statistics = data;
      });
      this.tests = this.testService.getTests();
    }
  }

  getTestName(test_id: number): string {
    for (let i = 0; i < this.tests.length; i++) {
      if (this.tests[i].id == test_id) {
        return this.tests[i].title;
      }
    }
  }

  getIsPassedString(isPassed: boolean): string {
    if (isPassed) {
      return 'Completed';
    }
    return 'Failed';
  }

  roundNumber(numberToRound: number, symbolsCount: number): number {
    let x = Math.pow(10, symbolsCount);
    return (parseInt(String(numberToRound * x))) / x;
  }
}
