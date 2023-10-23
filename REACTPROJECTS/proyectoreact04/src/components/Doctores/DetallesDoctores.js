import {Component} from 'react';
import Globals from '../../Globals';
import axios from 'axios';

export default class DetallesDoctores extends Component{
    urlDoctoresAPI = Globals.urlDoctoresAPI;
    doctor_data = [];
    
    GetDoctor=()=>{
        let request = '/api/Doctores/' + this.props.idDoctor; 
        axios.get(this.urlDoctoresAPI + request).then(response=>{
            this.doctor_data = response.data;
        })
    }

    render(){
        return(<div>
                {this.doctor_data}
            </div>)
    }

}