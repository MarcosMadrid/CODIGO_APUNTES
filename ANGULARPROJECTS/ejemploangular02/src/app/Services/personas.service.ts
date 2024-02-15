import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';

import { Persona } from '../Models/persona';
import Globals from 'src/assets/GLOBALS';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {

  constructor(private _http : HttpClient) {}

  GET_Personas() : Array<Persona>{
    var personas : Array<Persona> = []
    return personas;
  }

  GET_Personas_Promesa() : Promise<any> {
    var request : string = '/api/personas';
    let promise = new Promise((resolve)=>{
      this._http.get(environment.urlPersonasAPI + request).subscribe((response)=>{
        resolve(response);
      });
    }).catch((error)=>{
      (error);
    });
    
    return(promise);
  }
}
