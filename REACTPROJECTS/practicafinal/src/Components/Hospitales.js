import {Component} from 'react';
import Globals from '../Globals';
import axios from 'axios';
import HospitalesOficios from './HospitalesOficios';
import HospitalesDetalles from './HospitalesDetalles';

export default class Hospitales extends Component{
    urlAzureAPI = Globals.urlAzureAPI;

    state={
        hospitales : [],
        oficios_select : null,
        hospitales_oficios : null,
        hospitales_detalles : null,
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

        this.Render_HospitalesDetallles(options);
        this.Render_HospitalesOficios(options)
    }

    Render_HospitalesOficios =(options)=>{  
        var hospitales_oficios = []
        options.map((option, index)=>{
            hospitales_oficios.push(<HospitalesOficios key={index} id_hospital={option.value}/>)
        });
        this.setState({
            hospitales_oficios : hospitales_oficios
        });        
    }

    Render_HospitalesDetallles = (options)=>{
        var idHospitales = [];
        options.map((option, index)=>{
            idHospitales.push(option.value);
        });
        this.setState({
            hospitales_detalles : <HospitalesDetalles id_hospitales={idHospitales}/>
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
            {this.state.hospitales_oficios}
            <hr></hr>
            {this.state.hospitales_detalles}
        </div>);
    }
}