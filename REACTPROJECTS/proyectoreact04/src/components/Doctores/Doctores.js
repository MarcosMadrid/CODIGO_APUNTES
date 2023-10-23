import axios from "axios";
import {Component} from 'react';
import Globals from "../../Globals";
import DetallesDoctores from "./DetallesDoctores";

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
        let detalles = (<DetallesDoctores idDoctor={id_doctor}/>)
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
                <ul>
                {
                    this.state.doctores.map((doctor,index)=>{
                        return(<li key={index} onClick={this.LoadDetallesDoctor(doctor.idDoctor)}>{doctor.apellido}</li>);
                    })
                }
                </ul>
                {this.state.detalles}
            </div>
        )
    }
}