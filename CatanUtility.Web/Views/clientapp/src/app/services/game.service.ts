import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';


@Injectable()
export class GameService {
    headers: HttpHeaders = new HttpHeaders();

  constructor(private http: HttpClient) { 
    this.headers.append('Content-Type','application/json');
  }

  getStuff = (): Observable<any> => {
      return this.http.get('https://localhost:5001/api/board', { headers: this.headers }).pipe(map((response: any) => {
        return response;
      }));
  }

}