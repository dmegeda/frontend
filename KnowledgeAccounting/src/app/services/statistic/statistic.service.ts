import { StatisticDetails } from './../../interfaces/statistic-details';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Statistic } from './../../interfaces/statistic';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StatisticService {

  private url = 'https://localhost:44366/api/statistic';

  constructor(private http: HttpClient) { }

  createStatistic(statistic: Statistic) {
    return this.http.post(this.url + '/create', statistic);
  }

  getUserStatistic(user_id: string): Observable<StatisticDetails[]> {
    return this.http.get<StatisticDetails[]>(this.url + '/' + user_id);
  }
}
