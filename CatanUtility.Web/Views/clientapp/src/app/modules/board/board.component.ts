import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent implements OnInit {

  private _hexes: string;

  @Input() set hexes(hexes: any) {
    this._hexes = hexes;
    if (hexes){
      this.firstRowHexes = this.hexes.slice(0,3);
      this.secondRowHexes = this.hexes.slice(3,7);
      this.thirdRowHexes = this.hexes.slice(7,12);
      this.fourthRowHexes = this.hexes.slice(12,16);
      this.fifthRowHexes = this.hexes.slice(16,20);
    }
 }
 
 get hexes(): any {
     return this._hexes;
 }

  firstRowHexes: any;
  secondRowHexes: any;
  thirdRowHexes: any;
  fourthRowHexes: any;
  fifthRowHexes: any;

  constructor() { }

  ngOnInit(): void {
  }

}
