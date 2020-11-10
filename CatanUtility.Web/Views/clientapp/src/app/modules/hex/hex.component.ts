import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-hex',
  templateUrl: './hex.component.html',
  styleUrls: ['./hex.component.scss']
})
export class HexComponent implements OnInit {

  @Input() hex: any;

  constructor() { }

  ngOnInit(): void {
  }

}
