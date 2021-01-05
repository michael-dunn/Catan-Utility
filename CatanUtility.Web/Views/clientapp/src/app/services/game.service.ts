import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map} from 'rxjs/operators';
import { Game } from '../models/game';
import { Hex } from '../models/hex';
import { BuildingForm } from '../models/buildingForm';


@Injectable()
export class GameService {
    headers: HttpHeaders = new HttpHeaders();

  constructor(private http: HttpClient) { 
    this.headers.append('Content-Type','application/json');
  }

  GetTestGame = (): Observable<Game> => {
    return this.http.get('https://localhost:5001/api/game/GetTestGame', { headers: this.headers }).pipe(map((response: any) => {
      return response as Game;
    }));
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

  SetHex = (boardId: number, hex: Hex): Observable<any> => {
    return this.http.post(`https://localhost:5001/api/game/SetHex?boardId=${boardId}`, hex, { headers: this.headers }).pipe(map((response: any) => {
      return response;
    }));
  }

  AddBuilding = (boardId: number, buildingForm: BuildingForm): Observable<any> => {
    return this.http.post(`https://localhost:5001/api/game/AddBuilding?boardId=${boardId}`, buildingForm, { headers: this.headers }).pipe(map((response: any) => {
      return response;
    }));
  }

}