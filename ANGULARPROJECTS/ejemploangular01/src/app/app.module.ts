import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { routing, appRoutingProvider } from 'src/app.routing';

import { AppComponent } from './app.component';
import { HomeComponent } from './Components/home/home.component';
import { CineComponent } from './Components/cine/cine.component';
import { MusicaComponent } from './Components/musica/musica.component';
import { Error404Component } from './Components/error404/error404.component';
import { NumerodobleComponent } from './Components/numerodoble/numerodoble.component';
import { CollatzComponent } from './Components/collatz/collatz.component';
import { ListaproductosComponent } from './Components/listaproductos/listaproductos.component';
import { DetalleproductoComponent } from './Components/detalleproducto/detalleproducto.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CineComponent,
    MusicaComponent,
    Error404Component,
    NumerodobleComponent,
    CollatzComponent,
    ListaproductosComponent,
    DetalleproductoComponent
  ],
  imports: [
    BrowserModule, routing
  ],
  providers: [appRoutingProvider],
  bootstrap: [AppComponent]
})
export class AppModule { 

}
