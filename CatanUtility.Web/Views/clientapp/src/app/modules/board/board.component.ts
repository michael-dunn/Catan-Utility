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
      this.firstRowHexes = this.hexes.slice(0,3);
      this.secondRowHexes = this.hexes.slice(3,7);
      this.thirdRowHexes = this.hexes.slice(7,12);
      this.fourthRowHexes = this.hexes.slice(12,16);
      this.fifthRowHexes = this.hexes.slice(16,20);
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

  constructor() { }

  ngOnInit(): void {
  }

}
