// import axios from "axios";
import Globals from "@/Globals";

export default class ServiceCoche{

    GET_Coches(){
        var request = '/api/coches/';
        return ( new Promise(function(resolve){            
            // axios.get(Globals.urlCochesAPI + request).then(response=>{
            //     resolve(response.data);
            // }).catch(error=>{
            //     console.log(error.message);
            // });
            fetch(Globals.urlCochesAPI + request,
                {
                    method: "GET",                           
                }
            ).then((response)=>{ 
                resolve(response.json());
            });
        }))
    }

    GET_Coche(id_coche){
        var request = '/api/coches/findcoche/' + parseInt(id_coche);
        return ( new Promise(function(resolve){            
            // axios.get(Globals.urlCochesAPI + request).then(response=>{
            //     resolve(response.data);
            // }).catch(error=>{
            //     console.log(error.message);
            // });
            fetch(Globals.urlCochesAPI + request,
                {
                    method: "GET",                           
                }
            ).then((response)=>{ 
                resolve(response.json());
            });
        }))
    }

    UPDATE_Coche(coche){
        var request = '/api/coches/updatecoche';        
        // axios.put(Globals.urlCochesAPI + request, coche).then(response=>{
        //     console.log(response)
        // }).catch(error=>{
        //     console.log(error.message);
        // });  
        return( new Promise(function(resolve){
            fetch(Globals.urlCochesAPI + request,
            {
                method: "PUT",
                body: JSON.stringify(coche),  
                headers: {
                    "Content-Type": "application/json",                    
                }             
            }
            ).then((response)=>{ 
                resolve(response);
            });
        }));        
    }

    CREATE_Coche(coche){
        var request = '/api/coches/insertcoche';   
        return( new Promise(function(resolve){
            fetch(Globals.urlCochesAPI + request,
                {
                    method: "POST",
                    body:  JSON.stringify(coche),  
                    headers: {
                        "Content-Type": "application/json",                    
                    }          
                }
            ).then(response=>{ 
                resolve(response);
            }).catch(error=>{
                resolve(error);
            });  
        })

        )     
        // axios.post(Globals.urlCochesAPI + request, coche).then(response=>{
        //     console.log(response);
        // }).catch(error=>{
        //     console.log(error.message);
        // });
                
    }

    DELETE_Coche(id_coche){
        var request = '/api/coches/deletecoche/'+ parseInt(id_coche);        
        // axios.delete(Globals.urlCochesAPI + request).then(response=>{
        //     console.log(response);
        // }).catch(error=>{
        //     console.log(error.message);
        // });
        return( new Promise(function(resolve){
            fetch(Globals.urlCochesAPI + request)
                .then(response => resolve(response))
                .catch(error => resolve(error));
        }));
    }

    

}