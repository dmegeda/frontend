import { map, catchError } from 'rxjs/operators';
import { Test } from './../../interfaces/test';
import { Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tests } from './../../constant_data/tests';

@Injectable({
  providedIn: 'root'
})
export class TestService {

constructor(private http: HttpClient) { }

  private url = 'https://localhost:44366/api/tests';
  getTests(): Test[]{
    return tests;
  }

  getTest(id: number): Observable<Test> {
    return this.http.get<Test>(this.url + '/' + id);
  }
}
