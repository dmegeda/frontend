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

  loaded: boolean = false;
  tests: Test[] = [];

  ngOnInit(): void {
    this.tests = this.testService.getTests();
    this.loaded = true;
  }

}
