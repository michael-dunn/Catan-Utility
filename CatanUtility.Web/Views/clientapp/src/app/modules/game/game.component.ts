import { Component, OnInit } from '@angular/core';
import { Game } from 'src/app/models/game';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {

  game: Game;

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    // this.gameService.GetNewGame().subscribe(data => {
    //   this.game = data;
    // });

    this.gameService.GetGame(0).subscribe(data => {
      this.game = data;
    });
  }

}
