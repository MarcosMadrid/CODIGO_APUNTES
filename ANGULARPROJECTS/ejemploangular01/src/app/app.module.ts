import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { routing, appRoutingProvider } from 'src/app.routing';

import { AppComponent } from './app.component';
import { HomeComponent } from './Components/home/home.component';
import { Error404Component } from './Components/error404/error404.component';
import { NumerodobleComponent } from './Components/numerodoble/numerodoble.component';
import { CollatzComponent } from './Components/collatz/collatz.component';
import { ListaproductosComponent } from './Components/listaproductos/listaproductos.component';
import { DetalleproductoComponent } from './Components/detalleproducto/detalleproducto.component';
import { MenuComponent } from './Components/menu/menu.component';
import { ListascochesComponent } from './Components/listascoches/listascoches.component';
import { DetallescochesComponent } from './Components/detallescoches/detallescoches.component';
import { ListacomicsComponent } from './Components/Comic/listacomics/listacomics.component';
import { ComicComponent } from './Components/Comic/comic/comic.component';
import { FormComicComponent } from './Components/Comic/form-comic/form-comic.component';
import { ComicsService } from './services/comics.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    Error404Component,
    NumerodobleComponent,
    CollatzComponent,
    ListaproductosComponent,
    DetalleproductoComponent,
    MenuComponent,
    ListascochesComponent,
    DetallescochesComponent,
    ListacomicsComponent,
    ComicComponent,
    FormComicComponent

  ],
  imports: [
    BrowserModule, FormsModule ,routing
  ],
  providers: [appRoutingProvider, ComicsService],
  bootstrap: [AppComponent]
})
export class AppModule { 

}
