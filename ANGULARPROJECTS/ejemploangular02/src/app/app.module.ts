import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { appRoutingProvider, routing } from './app.routing';
import {FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MenuComponent } from './Components/menu/menu.component';
import { HomeComponent } from './Components/home/home.component';
import { PersonasService } from './Services/personas.service';
import { HttpClientModule } from '@angular/common/http';
import { PersonasComponent } from './Components/personas/personas.component';
import { DetallescochesComponent } from './Components/Coches/detallescoches/detallescoches.component';
import { EmpleadosComponent } from './Components/Empleados/empleados/empleados.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    PersonasComponent,
    DetallescochesComponent,
    EmpleadosComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    routing
  ],
  providers: [PersonasService, appRoutingProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
