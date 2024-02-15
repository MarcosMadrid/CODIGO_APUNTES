import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import Departamento from '../Models/departamento';

@Injectable({
  providedIn: 'root'
})
export class DepartamentosService {

  constructor(private _http : HttpClient) { 
  }

  GET_Departamentos():Promise<any>{
    var request : string = '/api/departamentos/';
    return(new Promise ((resolve)=>{
      this._http.get(environment.urlDepartamentosAPI + request, {observe : 'response'}).subscribe(response=>{
        resolve(response);
      });
    }).catch(error=>{
      console.log(error.message);
    }));
  }

  INSERT_Departamento(departamento : Departamento) : Promise<any>{
    var JSON_departamento = JSON.stringify(departamento);
    var header = new HttpHeaders().set("content-type", "application/json");
    var request : string = '/api/departamentos';

    return ( new Promise((resolve)=>{
      this._http.post(environment.urlDepartamentosAPI + request, JSON_departamento, {headers : header, observe : 'response'}).subscribe(response=>{
        resolve(response);
      });
    }).catch(error=>{
      console.log(error);
    }));
  }

  UPDATE_Departamento(departamento : Departamento) : Promise<any>{
    var JSON_departamento = JSON.stringify(departamento);
    var header = new HttpHeaders().set("content-type", "application/json");
    var request : string = '/api/departamentos';

    return ( new Promise((resolve)=>{
      this._http.put(environment.urlDepartamentosAPI + request, JSON_departamento, {headers: header, observe: 'response'}).subscribe(response=>{
        resolve(response);
      });
    }).catch(error=>{
      console.log(error);
    }));
  }
  
  DELETE_Departamento(id : number): Promise<any>{
    var header = new HttpHeaders().set("content-type", "application/json");
    var request : string = '';
    return ( new Promise( (resolve)=>{
      this._http.delete(environment.urlDepartamentosAPI + request , {headers : header} ).subscribe(response=>{        
        resolve(console.log(response));
      });
    }).catch(error=>{
      console.log(error);
    })
    );
  }

}
