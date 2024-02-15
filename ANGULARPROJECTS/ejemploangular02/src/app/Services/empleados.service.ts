import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  constructor(private _htt : HttpClient) { }
  GET_Funciones() : Promise<any>{
    const request : string = '/api/Plantilla/Funciones';
    return(new Promise((resolve)=>{
      this._htt.get(environment.urlEmpleadosAPI+ request).subscribe((response)=>{
        resolve(response as Array<any>);
      });
      }).catch(error=>{
        console.log(error);
      })
    );
  }

  GET_EmpleadosFunciones(funcion : string): Promise<any>{
    const request : string = '/api/Plantilla/PlantillaFuncion/' + funcion;
    return(new Promise((resolve)=>{
      this._htt.get(environment.urlEmpleadosAPI + request).subscribe((response)=>{
        resolve(response);
      });
      }).catch(error=>{
        console.log(error);
      })
    );
  }
}
