import {Component} from 'react';
import axios from 'axios';
import Globals from '../Globals';
import EmpleadosDetalles from './EmpleadosDetalles';

export default class HospitalesOficios extends Component{
    urlAzureAPI = Globals.urlAzureAPI;
    
    state={
        empleados: [],
        idHospital : null,
        extension_empleados : []
    }

    GET_OficiosHospital=()=>{
        var request = 'api/trabajadores/trabajadoreshospital/' + this.props.id_hospital;
        axios.get(this.urlAzureAPI + request).then(response=>{
            this.setState({
                empleados : response.data
            });
        }).catch(error=>{
            console.log(error.message);
        });
    }

    Render_OptionsOficios=()=>{
        var options = [];
        this.state.empleados.map((empleado, index)=>{
            options.push(<option value={empleado.oficio} key={index+1}>
                {empleado.oficio.toUpperCase()}
            </option>);
        });
        return(options);
    }
    
    Render_OficiosHospital = (event)=>{

        this.setState({
            extension_empleados : <EmpleadosDetalles id_hospital={event.currentTarget.value}/>
        });
    }

    componentDidMount=()=>{
        this.setState({
            idHospital : this.props.id_hospital
        });
        this.GET_OficiosHospital();
    }

    componentDidUpdate=(before)=>{
        if(before.id_hospital !== this.props.id_hospital){
            this.setState({
                idHospital : this.props.id_hospital
            });
            this.GET_OficiosHospital();
        }        
    }

    render(){
        return(<div id='HospitalesOficios'>            
            <select className="form-select form-select-sm" aria-label=".form-select-sm example" onChange={(event)=>this.Render_OficiosHospital(event)} >
                <option value={-1} key={0}>Vacio</option>
                {this.Render_OptionsOficios()}
            </select>
            {this.state.extension_empleados}
        </div>);
    }
}