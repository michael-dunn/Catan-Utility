import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GameComponent } from './modules/game/game.component';
import { HomeComponent } from './modules/home/home.component';
import { GameService } from './services/game.service';
import { HttpClientModule } from '@angular/common/http';
import { BoardComponent } from './modules/board/board.component';
import { HexComponent } from './modules/hex/hex.component';

@NgModule({
  declarations: [
    AppComponent,
    GameComponent,
    HomeComponent,
    BoardComponent,
    HexComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [GameService],
  bootstrap: [AppComponent]
})
export class AppModule { }
