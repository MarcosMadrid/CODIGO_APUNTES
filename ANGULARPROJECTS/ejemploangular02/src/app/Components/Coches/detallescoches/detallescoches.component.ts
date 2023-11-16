import { Component, OnInit } from '@angular/core';
import Coche from 'src/app/Models/coches';
import { CochesService } from 'src/app/Services/coches.service';

@Component({
  selector: 'app-detallescoches',
  templateUrl: './detallescoches.component.html'
})
export class DetallescochesComponent implements OnInit{
  coches : Array<Coche> = [];
  
  constructor(private _serviceCoches : CochesService){

  }
  
  ngOnInit(): void {
    this._serviceCoches.GET_Coches().then((response : Array<Coche>) =>{
      response.forEach((coche: Coche) => {        
        this.coches.push(Object.assign(new Coche() , coche));
      });
    }).catch(error=>{
      console.log(error.message);
    });
  }
}
