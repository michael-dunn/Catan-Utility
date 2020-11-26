import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map} from 'rxjs/operators';
import { Game } from '../models/game';


@Injectable()
export class GameService {
    headers: HttpHeaders = new HttpHeaders();

  constructor(private http: HttpClient) { 
    this.headers.append('Content-Type','application/json');
  }

  GetNewGame = (): Observable<Game> => {
    return this.http.get('https://localhost:5001/api/game/GetNewGame', { headers: this.headers }).pipe(map((response: any) => {
      return response as Game;
    }));
  }

  GetGame = (id: number): Observable<Game> => {
      return this.http.get(`https://localhost:5001/api/game/GetGame?id=${id}`, { headers: this.headers }).pipe(map((response: any) => {
        return response as Game;
      }));
  }

  DeleteAllGames = (): Observable<any> => {
    return this.http.get('https://localhost:5001/api/game/DeleteAllGames', { headers: this.headers }).pipe(map((response: any) => {
      return response;
    }));
}

}