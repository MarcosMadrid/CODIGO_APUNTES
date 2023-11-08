import { Component } from '@angular/core';

@Component({
  selector: 'app-primercomponent',
  templateUrl: './primercomponent.component.html',
  styleUrls: ['./primercomponent.component.css']

})
export class PrimercomponentComponent {
  public titulo: string;
  public descripcion: string;
  public anyo: number;

  constructor(){
    this.anyo = 2023;
    this.titulo = "Primero de ESPAÑA";
    this.descripcion = "HOLA MUY WENAS MASTOKING";
  }
}
