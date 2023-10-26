import {Component} from 'react';
import axios from 'axios';
import Globals from '../Globals';

export default class EmpleadosDetalles extends Component{

    state={
        empleados : null
    }

    GET_TrabajadoresHospital=()=>{
        var request = 'api/trabajadores/trabajadoresoficios/?oficio=' + this.props.id_hospital;
        axios.get(Globals.urlAzureAPI + request).then(response=>{
            this.setState({
                empleados : response.data
            });
        }).catch(error=>{
            console.log(error.message);
        });
    }

    Render_DetallesEmpleados=()=>{
        if(this.state.empleados.length === 0)
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

    componentDidMount = ()=>{
        this.GET_TrabajadoresHospital();
    }

    componentDidUpdate = (before)=>{
        if(before.id_hospital !== this.props.id_hospital){
            this.GET_TrabajadoresHospital();
        }
    }

    render(){
        return(<div>
            {this.Render_DetallesEmpleados()}
        </div>);
    }
}