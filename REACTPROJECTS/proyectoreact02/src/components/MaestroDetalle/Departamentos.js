import { Component } from "react";
import Global from "../../Global";
import axios from 'axios';
import React from "react";
import Empleados from "./Empleados";

export default class Departamentos extends Component{
    urlApiDepartamentos = Global.urlApiDepartamentos;
    urlApiEmpleados = Global.urlApiEmpleados;
    select_dept = React.createRef();

    state={
        id_dept : null,
        departamentos : [],     
        EmpleadosComponent : null  
    }

    GetDepartamentos = ()=>{
        let request = 'api/departamentos';
        axios.get(this.urlApiDepartamentos + request).then(response=>{
            this.setState({
                departamentos : response.data
            });
        })
    }

    GetEmpleadosDepartamento= (id_dept)=>{
        let request = 'api/empleados/empleadosdepartamento/';
        return axios.get(this.urlApiEmpleados + request + id_dept).then(response=>{
            return(response.data);
        });
    }

    EmpleadosComponent=(e)=>{    
        e.preventDefault();   

        this.setState({
            id_dept : this.select_dept.current.value,
            EmpleadosComponent: 
                <Empleados 
                        id_departamento = {this.select_dept.current.value}                        
                        GetEmpleadosDepartamento = {this.GetEmpleadosDepartamento}
                />
        });
    };
           
    

    LoadOptionsDept=()=>{
        let options = []
        this.state.departamentos.map((departamento,index)=>{
            options.push(<option 
                            key={index} 
                            value={departamento.Numero}>
                            {departamento.Nombre}
                        </option>);
            return(null);
        });
        return(options);
    }

    componentDidMount = ()=>{
        this.GetDepartamentos();
    }

    render(){
        return(<div>
            <h1>Departamentos Component</h1>
            <form>
                <label>Seleccione departamento</label>
                <select ref={this.select_dept}>
                    {this.LoadOptionsDept()}
                </select>
                <button onClick={
                    (e)=>{this.EmpleadosComponent(e)}
                }>Buscar Empleados</button>
                <h2>departamento Seleccionado {this.state.id_dept}</h2>
            </form>
            {this.state.EmpleadosComponent}
        </div>);
    }
}