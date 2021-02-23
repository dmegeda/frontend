import { TestService } from './../../services/test/test.service';
import { Test } from './../../interfaces/test';
import { Component, OnInit } from '@angular/core';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private testService: TestService) { }

  loaded = false;
  tests: Test[] = [];

  ngOnInit(): void {
    this.testService.getTests().subscribe((data) => {
      this.tests = data;
      this.loaded = true;
    });
  }

}
