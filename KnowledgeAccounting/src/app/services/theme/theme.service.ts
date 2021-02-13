import { Theme } from '../../interfaces/theme';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  constructor(private http: HttpClient) { }

  private url = 'https://localhost:44366/api/theme';

  getThemes(): Observable<Theme[]> {
    return this.http.get<Theme[]>(this.url).pipe(
      map((data: Theme[]) => {
        return data;
      }),
      catchError(error => {
        console.log(error);
        return throwError(error)
      })
    );
  }
}
