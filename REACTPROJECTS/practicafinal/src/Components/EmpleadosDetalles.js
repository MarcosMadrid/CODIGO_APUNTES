import {Component} from 'react';
import axios from 'axios';
import Globals from '../Globals';
import InputSalario from './InputSalario';

export default class EmpleadosDetalles extends Component{

    state={
        empleados : null
    }

    GET_TrabajadoresHospital=()=>{
        var mensaje = '';
        this.props.id_hospitales.forEach(id_hospital => {
            mensaje += "idhospital=" + id_hospital + "&";
        });     
        var request = 'api/trabajadores/trabajadoreshospitales?'+ mensaje;
        axios.get(Globals.urlAzureAPI + request).then(response=>{
            this.setState({
                empleados : response.data
            });
        }).catch(error=>{
            console.log(error.message);
        });        
    }



    Render_DetallesEmpleados=()=>{
        if(this.state.empleados === null)
            return;
        return(
        <table className="table">
            <thead>
                <tr>
                {
                    Object.keys(this.state.empleados[0]).map((key, index_key)=>{
                        return(<th key={index_key}>{key.toUpperCase()}</th>);
                    })
                }
                </tr>
            </thead>
            <tbody>               
                {
                    this.state.empleados.map((empleado, index_empeado)=>{
                        var cells = [];
                        Object.values(empleado).map((value,index_value)=>{
                            cells.push(<td key={index_value}>{value}</td>);
                        });
                        return(<tr key={index_empeado}>{cells}</tr>);
                    }) 
                }                
            </tbody>
        </table>);
    }

    Render_SalarioInput= ()=>{
        if(this.state.empleados === null)
            return;
        return(<InputSalario id_hospitales={this.props.id_hospitales} GET_TrabajadoresHospital={this.GET_TrabajadoresHospital}/>)
    }

    componentDidMount = ()=>{
        this.GET_TrabajadoresHospital();
    }

    componentDidUpdate = (before)=>{
        if(before.id_hospitales !== this.props.id_hospitales){
            this.GET_TrabajadoresHospital();
        }
    }

    render(){
        return(<div>
            {this.Render_DetallesEmpleados()}
            {this.Render_SalarioInput()}
        </div>);
    }
}