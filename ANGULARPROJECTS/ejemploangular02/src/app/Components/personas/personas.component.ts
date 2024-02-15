import { Component, OnInit } from '@angular/core';
import { Persona } from 'src/app/Models/persona';
import { PersonasService } from 'src/app/Services/personas.service';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html'
})
export class PersonasComponent implements OnInit{
  personas : Array<Persona> = [];
  constructor(private _servicePersona : PersonasService){

  }
  ngOnInit(): void {
    this._servicePersona.GET_Personas_Promesa().then(response=>{
      this.personas = response;
    })
  }
}
