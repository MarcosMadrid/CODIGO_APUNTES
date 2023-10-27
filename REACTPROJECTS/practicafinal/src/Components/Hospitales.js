import {Component} from 'react';
import Globals from '../Globals';
import axios from 'axios';
import EmpleadosDetalles from './EmpleadosDetalles';

export default class Hospitales extends Component{
    urlAzureAPI = Globals.urlAzureAPI;

    state={
        hospitales : [],
        oficios_select : null,
        hospitales_empleados : null,
    }

    GET_Hospitales=()=>{
        var request = 'api/hospitales';
        axios.get(this.urlAzureAPI + request).then(response=>{
            this.setState({
                hospitales : response.data
            });
        }).catch(error=>{
            console.log(error.message);
        })
    }

    Render_OptionsHospitales=()=>{
        var options = []
        this.state.hospitales.map((hospital,index)=>{
            options.push
            (<option key={index+1} value={hospital.idHospital}>
                {hospital.nombre}
            </option>);
        })
        return(options);
    }

    EventSelectHospital = (event)=>{
        event.preventDefault();       
        var select = event.currentTarget;
        var options = [...select.selectedOptions];

        this.Render_HospitalesOficios(options)
    }

    Render_HospitalesOficios =(options)=>{  
        var id_hospitales = [] 
        options.map((option, index_option)=>{
            id_hospitales.push(option.value);
        });

        this.setState({
            hospitales_empleados : <EmpleadosDetalles id_hospitales={id_hospitales}/>
        });        
    }

    componentDidMount = ()=>{
        this.GET_Hospitales();
    }

    render(){
        return(<div id='Hospitales'>
            <select className="form-select"  onChange={(event)=>this.EventSelectHospital(event)} multiple>               
                {this.Render_OptionsHospitales()}
            </select>
            <hr></hr>
            {this.state.hospitales_empleados}
        </div>);
    }
}