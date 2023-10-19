import { Component, createRef } from "react";
import Global from "../Global";
import axios from "axios";

export default class ServiceEmpleadosDepartamentos extends Component{
    urlApiEmpleados = Global.urlApiEmpleados;
    urlApiDepartamentos = Global.urlApiDepartamentos;
    select_dept = createRef();

    state={
        empleados : [],
        departamentos : []
    }

    GetEmpleados= ()=>{
        let request = 'api/Empleados';
        axios.get(this.urlApiEmpleados + request).then(response=>{
            this.setState({
                empleados: response.data
            });
        });
    }

    GetDepartamentos= ()=>{
        let request = '/api/departamentos';
        axios.get(this.urlApiDepartamentos + request).then(response=>{
            this.setState({
                departamentos: response.data.filter(departamento => departamento.Nombre)
            });
        });
    }

    GetEmpleadosDept= ()=>{
        if(this.select_dept.current.value === 'Ninguno'){
            this.GetEmpleados();
            return;
        }
        let dept_no = parseInt(this.select_dept.current.value);
        let request = 'api/Empleados/EmpleadosDepartamento/'+ dept_no;
        axios.get(this.urlApiEmpleados + request).then(response=>{
            this.setState({
                empleados: response.data
            });
        });        
    }

    OptionsDepartamentos= ()=>{
        let options = [];
        this.state.departamentos.map((departamento, index)=>{
            options.push(<option key={index} value={departamento.Numero}>{departamento.Nombre}</option>)
        })
        return(options);
    }

    ListEmpleados = ()=>{
        let tbody = [];
        this.state.empleados.map((empleado, index) => {   
            let cells = [];
            Object.values(empleado).forEach((value, valueIndex) => {
                let cell = <td key={valueIndex}>{value}</td>;               
                cells.push(cell);
            });  
            let row = (<tr key={index}><td>{index}</td>{cells}</tr>);
            tbody.push(row);
        });
        return(tbody)
    }

    componentDidMount = ()=>{
        this.GetEmpleados();
        this.GetDepartamentos();
        this.select_dept.current.addEventListener("change", ()=>{
            this.GetEmpleadosDept();   
        });
    }

    render(){
        return(<div>
            <h1>ServiceEmpleados</h1>
            <select placeholder="Nombre Dept" ref={this.select_dept}>
            <option key={-1}>Ninguno</option>
            {this.OptionsDepartamentos()}
            </select>
            <table> 
                <tbody>
                    {this.ListEmpleados()}
                </tbody>
            </table>
        </div>);
    }
}