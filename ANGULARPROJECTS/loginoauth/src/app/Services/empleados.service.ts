import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import User from '../Models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  constructor(private _http : HttpClient) { }

  GET_TOKEN(user : User):Promise<any>{
    var request : string = '/Auth/Login';
    var JSON_user : string= JSON.stringify(user)
    const headers= new HttpHeaders()
      .set('content-type', 'application/json')
      .set('Access-Control-Allow-Origin', '*');
    return(new Promise((resolve)=>{
      this._http.post(environment.urlEmpleadosAPI + request , JSON_user,  {headers: headers , observe : 'response'} )
      .subscribe(
        response=>{
          resolve(response);
        }, 
        error =>{
          console.log(error)
          resolve(error);
        }
      );
    }).catch(error=>{
      return(error)
    }));
  }
  
  GET_Empleados(token : string ): Promise<any>{
    var request : string = '/api/Empleados';
    const headers= new HttpHeaders()
      .set('content-type', 'application/json')
      .set('Access-Control-Allow-Origin', '*')
      .set('Authorization', "bearer "+token);
      
    return(new Promise((resolve)=>{
      this._http.get(environment.urlEmpleadosAPI + request ,  {headers: headers , observe : 'response'} )
      .subscribe(
        response=>{
          resolve(response);
        }, 
        error =>{
          resolve(error);
        }
      );
    }).catch(error=>{
      return(error)
    }));
  }
}
