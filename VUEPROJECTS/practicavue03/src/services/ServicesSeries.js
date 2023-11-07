import axios from "axios";
import Globals from "@/Globals";


export default class ServicesSeries {
    GET_Series(){
        var request = '/api/Series/';
        return ( new Promise(function(resolve){
            axios(Globals.urlSeriesAPI + request)
            .then(response=>{
                resolve(response);
            }).catch(error=>{
                resolve(error);
            });
        }));
    }

    GET_Serie(id_serie){
        var request = '/api/Series/' + parseInt(id_serie);
        return ( new Promise(function(resolve){
            axios(Globals.urlSeriesAPI + request)
            .then(response=>{
                resolve(response);
            }).catch(error=>{
                resolve(error);
            });
        }));
    }

    GET_Personajes(id_series){
        var request= '/api/Series/PersonajesSerie/' + id_series;
        return(new Promise(function(resolve){
            axios.get(Globals.urlSeriesAPI + request)
            .then(response=>{
                resolve(response);
            })
            .catch(error=>{
                resolve(error);
            })
        }))
    }

    GET_Personaje(id_personaje){
        var request= '/api/Personajes/' + id_personaje;
        return(new Promise(function(resolve){
            axios.get(Globals.urlSeriesAPI + request)
            .then(response=>{
                resolve(response);
            })
            .catch(error=>{
                resolve(error);
            })
        }))
    }
}