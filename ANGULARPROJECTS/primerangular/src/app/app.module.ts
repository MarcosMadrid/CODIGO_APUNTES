import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { PrimercomponentComponent } from './components/primercomponent/primercomponent.component';
import { SegundocomponentComponent } from './components/segundocomponent/segundocomponent.component';
import { FormsBindingComponent } from './components/formbindingcomponent/formbinding.component';
import { TablamultiplicarcomponentComponent } from './components/tablamultiplicarcomponent/tablamultiplicarcomponent.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    PrimercomponentComponent,
    SegundocomponentComponent,
    FormsBindingComponent,
    TablamultiplicarcomponentComponent
  ],
  imports: [
    BrowserModule, FormsModule, NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
