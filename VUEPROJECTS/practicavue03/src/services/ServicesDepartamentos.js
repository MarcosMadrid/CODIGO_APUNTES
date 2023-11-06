import Globals from "@/Globals";
import axios from "axios";

export default class ServicesDepartamentos{

    GET_Departamentos(){
        var request = '/api/departamentos';
        return(new Promise(function(resolve){
            axios.get(Globals.urlDepartamentosAPI + request).then(response=>{
                resolve(response.data);
            }).catch(error=>{
                console.log(error.menssage);
            });
        }).catch(error=>{
            console.log(error.menssage);
        }));
    }

    GET_Departamento(id_departamento){
        var request = '/api/departamentos/' + id_departamento;
        return(new Promise(function(resolve){
            axios.get(Globals.urlDepartamentosAPI + request).then(response=>{
                resolve(response.data);
            }).catch(error=>{
                console.log(error.menssage);
            });
        }).catch(error=>{
            console.log(error.menssage);
        }));
    }

    INSERT_Departamento(departamento){
        var request = '/api/departamentos';
        return(new Promise(function(resolve){
            axios.post(Globals.urlDepartamentosAPI + request , departamento).then(response=>{
                resolve(response.data)
            }).catch(error=>{
                console.log(error.menssage);
            })
        }).catch(error =>{
            console.log(error.menssage);
        }));
    }

    UPDATE_Departamento(departamento){
        var request = '/api/departamentos';
        return(new Promise(function(resolve){
            axios.put(Globals.urlDepartamentosAPI + request , departamento).then(response=>{
                resolve(response.data)
            }).catch(error=>{
                console.log(error.menssage);
            })
        }).catch(error =>{
            console.log(error.menssage);
        }));
    }

    DELETE_Departamento(id_departamento){
        var request = '/api/departamentos/' + id_departamento;
        axios.delete(Globals.urlDepartamentosAPI + request).then(response=>{
            console.log(response);
        })
    }

}