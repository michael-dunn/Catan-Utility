import { Component, OnInit } from '@angular/core';
import { BuildingForm } from 'src/app/models/buildingForm';
import { Game } from 'src/app/models/game';
import { Hex } from 'src/app/models/hex';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {

  game: Game;

  buildingForm: BuildingForm;

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    this.buildingForm = new BuildingForm();
    this.getTestGame();
  }

  onSubmit(){
    this.gameService.AddBuilding(this.game.id, this.buildingForm).subscribe(data => {
      this.game = data;
    });
  }

  getTestGame() {
    this.gameService.GetTestGame().subscribe(data => {
      this.game = data;
    });
  }

  getNewGame() {
    this.gameService.GetNewGame().subscribe(data => {
      this.game = data;
    });
  }

  getGame(id: number){
    this.gameService.GetGame(id).subscribe(data => {
      this.game = data;
    });
  }

}
