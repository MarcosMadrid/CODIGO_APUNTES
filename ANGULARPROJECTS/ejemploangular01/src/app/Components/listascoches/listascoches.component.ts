import { Component } from '@angular/core';
import { Coche } from '../../Models/Coche';

@Component({
  selector: 'app-listascoches',
  templateUrl: './listascoches.component.html'
})
export class ListascochesComponent {
  public coches : Array<Coche> = [];

  Eliminar(id : number){
    
    this.coches.splice(id, 1);
  }
  
  CrearCoche(event: Event) {
    event.preventDefault();
    var form: Array<HTMLInputElement> = (event.target as unknown) as Array<HTMLInputElement>;
    var marca : string = form[0].value ?? '' ;
    var modelo : string = form[1].value ?? '' ;
    var velocidad : number = parseInt(form[2].value) ?? Number.NaN ;
    var aceleracion : number = parseInt(form[3].value) ?? Number.NaN ;
    var estado : boolean = form[4].checked ?? false ;

    var coche : Coche = new Coche();
    coche.Set_Marca(marca);
    coche.Set_Modelo(modelo);
    coche.Set_Velocidad(velocidad);
    coche.Set_Aceleracion(aceleracion);
    coche.Set_Estado(estado);

    this.coches.push(coche);
  }
}
