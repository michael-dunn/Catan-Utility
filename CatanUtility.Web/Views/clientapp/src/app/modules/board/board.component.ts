import { Component, Input, OnInit } from '@angular/core';
import { Hex } from 'src/app/models/hex';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent implements OnInit {

  private _hexes: Hex[];

  @Input() set hexes(hexes: Hex[]) {
    this._hexes = hexes;
    if (hexes){
      this.firstRowHexes = this.hexes.slice(0,5);
      this.secondRowHexes = this.hexes.slice(5,11);
      this.thirdRowHexes = this.hexes.slice(11,17);
      this.fourthRowHexes = this.hexes.slice(17,24);
      this.fifthRowHexes = this.hexes.slice(24,30);
      this.sixthRowHexes = this.hexes.slice(30,36);
      this.seventhRowHexes = this.hexes.slice(36,41);
    }
 }
 
 get hexes(): Hex[] {
     return this._hexes;
 }

  firstRowHexes: Hex[];
  secondRowHexes: Hex[];
  thirdRowHexes: Hex[];
  fourthRowHexes: Hex[];
  fifthRowHexes: Hex[];
  sixthRowHexes: Hex[];
  seventhRowHexes: Hex[];

  constructor() { }

  ngOnInit(): void {
  }

}
