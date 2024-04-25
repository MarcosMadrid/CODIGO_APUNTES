import axios from "axios";
import { Component } from "react";
import { Navigate } from "react-router-dom";

export default class CreateApuesta extends Component{

    
    Submit_Apuesta=(e)=>{
        e.preventDefault();
        console.log(e)
        var inputs = e.target;
        
        var usuario = inputs[0].value;
        var atletico = inputs[1].value;
        var realmadrid = inputs[2].value;
        var fecha = inputs[3].value;
        
        var resultado = atletico + "-" + realmadrid;
        
        var apuesta={
            usuario: usuario,
            resultado: resultado,
            fecha: fecha
        }
        
        this.INSERT_Apuesta(apuesta);
    }

    INSERT_Apuesta = (apuesta)=>{
        var request = '/api/apuestas/';
        axios.post(this.urlApuestasAPI + request , apuesta).then(response=>{
            <Navigate to={'/apuestas/'}></Navigate>
        }).catch(error=>{
            console.log(error.message);
        });
    }
    
    render(){
        return(<div>
            <div className="d-block mx-auto col-6">
            <form onSubmit={(e)=>this.Submit_Apuesta(e)}>
                <div className="mb-3">
                    <label htmlFor="input_usuario" className="form-label">USUARIO</label>
                    <input type="text" className="form-control" id="input_usuario" aria-describedby="input_usuario"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="input_atletico" className="form-label">ATLETICO</label>
                    <input type="text" className="form-control" id="input_atletico" aria-describedby="input_atletico"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="input_realMadrid" className="form-label">REAL MADRID</label>
                    <input type="text" className="form-control" id="input_realMadrid" aria-describedby="input_realMadrid"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="input_fecha" className="form-label">FECHA</label>
                    <input type="date" className="form-control" id="input_fecha" aria-describedby="input_fecha"/>
                </div>
                <button type="submit" className="btn btn-success">
                    Añadir
                </button>
            </form>
            </div>
        </div>);
    }
}