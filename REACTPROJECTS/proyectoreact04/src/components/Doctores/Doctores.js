import axios from "axios";
import {Component} from 'react';
import Globals from "../../Globals";
import DetallesDoctores from "./DetallesDoctores";
import { NavLink } from "react-router-dom";

export default class Doctores extends Component {
    urlDoctoresAPI = Globals.urlDoctoresAPI;
   
    state = {
        doctores: [],     
        detalles: null   
    }

    GetDoctores = ()=>{
        let request = 'api/Doctores/DoctoresHospital/' + this.props.idhospital;
        axios.get(this.urlDoctoresAPI + request).then(response=>{
            this.setState({
                doctores : response.data
            });
        });
    }

    LoadDetallesDoctor=(idDoctor)=>{
        let id_doctor = parseInt(idDoctor);
        let detalles = (<DetallesDoctores id_doctor={id_doctor}/>);
        this.setState({
            detalles : detalles
        })
    }

    componentDidUpdate = (before)=>{
        if(before.idhospital !== this.props.idhospital) {
            this.GetDoctores();
        }            
    }

    componentDidMount = ()=>{
        this.GetDoctores();
    }    


    render(){
        return(
            <div>
                <table className="table">
                    <thead>
                        <tr>
                        <th scope="col">APELLIDO</th>
                        <th scope="col">ESPECIALIDAD</th>
                        <th scope="col">Handle</th>                       
                        </tr>
                    </thead>
                    <tbody>
                    {
                        this.state.doctores.map((doctor,index)=>{
                            return(<tr key={index}>
                                <td>
                                    {doctor.apellido} 
                                </td>
                                <td>
                                    {doctor.especialidad}                             
                                </td>
                                <td>
                                    <button className="btn btn-primary" onClick={()=>this.LoadDetallesDoctor(doctor.idDoctor)}>
                                        Detalles
                                    </button>
                                </td>
                                <td>
                                    <NavLink 
                                        className = "dropdown-item" 
                                        to = {"/doctor/detalles/"+ doctor.idDoctor}>
                                        Doctor
                                    </NavLink>
                                </td>
                            </tr>);
                        })
                    }
                    </tbody>
                </table>          
                {this.state.detalles}
            </div>
        )
    }
}