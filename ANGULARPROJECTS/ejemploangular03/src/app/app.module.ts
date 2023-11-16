import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'

import { routing } from './app.routing';

import { AppComponent } from './app.component';
import { MenuComponent } from './Components/menu/menu.component';
import { HomeComponent } from './Components/home/home.component';

import { DepartamentosService } from './Services/departamentos.service';
import { FormDepartamentoComponent } from './Components/Departamentos/form-departamento/form-departamento.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    FormDepartamentoComponent
  ],
  imports: [
    BrowserModule,
    routing,
    NgbModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [DepartamentosService],
  bootstrap: [AppComponent]
})
export class AppModule { }
