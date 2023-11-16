import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { routing } from './app.routing';
import { FormsModule } from '@angular/forms';

import { MenuComponent } from './Components/menu/menu.component';
import { HomeComponent } from './Components/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { SeriesService } from './Services/series.service';
import { SerieComponent } from './Components/serie/serie.component';
import { PersonajesSeriesComponent } from './Components/personajes-series/personajes-series.component';
import { FormPersonajeComponent } from './Components/form-personaje/form-personaje.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    SerieComponent,
    PersonajesSeriesComponent,
    FormPersonajeComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    routing,
    FormsModule,
    HttpClientModule
  ],
  providers: [SeriesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
