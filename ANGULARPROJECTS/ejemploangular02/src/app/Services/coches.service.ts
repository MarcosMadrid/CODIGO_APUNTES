import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import Coche from '../Models/coches';

@Injectable({
  providedIn: 'root'
})
export class CochesService {

  constructor(private _http : HttpClient) { }

  GET_Coches() : Promise<any>{
    var request : string = '/webresources/coches';
    let promise = new Promise((resolve)=>{
      this._http.get(environment.urlCochesAPI + request).subscribe(response=>{
        resolve(response as Array<any>);
      });
    }).catch((error)=>{
      error
    });

    return(promise);
  }
}
