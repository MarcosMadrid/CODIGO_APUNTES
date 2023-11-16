import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SeriesService {

  constructor(private _http : HttpClient) { }

  GET_Series():Promise<any>{
    var request : string = '/api/Series';
    return(new Promise((resolve)=>{
      this._http.get(environment.urlSeriesAPI + request, {observe : 'response'}).subscribe(response=>{
        resolve(response);
      });
    }).catch(error=>{
      console.log(error);
    }));
  }

  GET_Serie(id : number):Promise<any>{
    var request : string = '/api/Series/' + id;
    return(new Promise((resolve)=>{
      this._http.get(environment.urlSeriesAPI + request, {observe : 'response'}).subscribe(response=>{
        resolve(response);
      });
    }).catch(error=>{
      console.log(error);
    }));
  }

  GET_Personajes_Serie(id : number): Promise<any>{
    var request : string = '/api/Series/PersonajesSerie/' + id;
    return(new Promise ((resolve)=>{
      this._http.get(environment.urlSeriesAPI + request, {observe : 'response'}).subscribe(response=>{
        resolve(response);
      })
    }).catch(error=>{
      console.log(error.message);
    }))
  }

}
