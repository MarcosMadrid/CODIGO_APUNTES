import { Component } from "react";
import React from "react";
import axios from "axios";
import Globals from "../../Globals";

export default class AyadirHospital extends Component{
    urlHospitalesAPI = Globals.urlHospitalesAPI;
    Input_idHospital = React.createRef();
    Input_Nombre = React.createRef();
    Input_Direccion = React.createRef();
    Input_Telefono = React.createRef();
    Input_Camas = React.createRef();

    SubmitHospital = (e)=>{
        e.preventDefault();

        var id_hospital = parseInt(this.Input_idHospital.current.value);
        var nombre = this.Input_Nombre.current.value;
        var direccion = this.Input_Direccion.current.value;
        var telefono = this.Input_Telefono.current.value;
        var camas = parseInt(this.Input_Camas.current.value);

        var hospital={
            idhospital: id_hospital,
            nombre : nombre,
            direccion : direccion,
            telefono : telefono,
            camas : camas
        }

        this.PostHospital(hospital);        
    }

    PostHospital = (hospital)=>{
        let request = '/webresources/hospitales/post';
        axios.post(this.urlHospitalesAPI + request,hospital).then(response=>{
            console.log(response);
        });
    }

    render(){
        return(
            <form>
                <div className="mb-3">
                    <label htmlFor="Input_idHospital" className="form-label">IdHospital</label>
                    <input type="text" ref={this.Input_idHospital} className="form-control" id="Input_idHospital" aria-describedby="IdHospital"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="Input_Nombre" className="form-label">Nombre</label>
                    <input type="text" ref={this.Input_Nombre} className="form-control" id="Input_Nombre"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="Input_Direccion" className="form-label">Dirección</label>
                    <input type="text" ref={this.Input_Direccion} className="form-control" id="Input_Direccion" aria-describedby="Dirección"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="Input_Telefono" className="form-label">Telefono</label>
                    <input type="text" ref={this.Input_Telefono} className="form-control" id="Input_Telefono" aria-describedby="Telefono"/>
                </div>
                <div className="mb-3">
                    <label htmlFor="Input_Camas" className="form-label">Camas</label>
                    <input type="text" ref={this.Input_Camas} className="form-control" id="Input_Camas" aria-describedby="Camas"/>
                </div>
                <button className="btn btn-primary" onClick={this.SubmitHospital}>Submit</button>
            </form>
        )
    }
}