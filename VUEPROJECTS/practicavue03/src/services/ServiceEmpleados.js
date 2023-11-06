import axios from "axios";
import Globals from "@/Globals";

export default class ServiceEmpleado{

    GET_EmpleadosOficio(oficio){
        var request = '/api/Empleados/EmpleadosOficio/' + oficio;

        return new Promise(function(resolve){            
            axios.get(Globals.urlEmpleadosAPI + request).then(response=>{      
                resolve(response.data)        
            }).catch(error=>{
                console.log(error.menssage);
            });             
        });
    }

    Get_Empleados(){
        var request = '/api/Empleados';
        return new Promise(function(resolve){           
            axios.get(Globals.urlEmpleadosAPI + request).then(response =>{
                resolve(response.data);
            }).catch(error=>{
                console.log(error.menssage);
            }); 
        })
    }

    Get_Empleado(id_empleado){
        var request = '/api/Empleados/' + id_empleado;
        return new Promise(function(resolve){           
            axios.get(Globals.urlEmpleadosAPI + request).then(response =>{
                resolve(response.data);
            }).catch(error=>{
                console.log(error.menssage);
            }); 
        })
    }
}