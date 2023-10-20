import { Component, createRef } from "react";
import Oficios from "./EmpleadosComponents/Oficios";
import Salarios from "./EmpleadosComponents/Salarios";
import Global from "../Global";
import axios from "axios";
import "./EmpleadosComponents/EmpleadosComponents.css";

export default class ServiceEmpleadosDepartamentos extends Component{
    urlApiEmpleados = Global.urlApiEmpleados;
    urlApiDepartamentos = Global.urlApiDepartamentos;
    select_dept = createRef();

    state={
        empleados : [],
        departamentos : [],
        childComponents : []
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

    GetOficios= (oficio)=>{
        let request = 'api/Empleados/EmpleadosOficio/' + oficio;
        return axios.get(this.urlApiEmpleados + request ).then(response=>{
            return(response.data);
        });        
    }

    GetSalarios= (salario)=>{
        let request = 'api/Empleados/EmpleadosSalario/' + salario;
        return axios.get(this.urlApiEmpleados + request ).then(response=>{
            return(response.data);
        });        
    }

    OptionsDepartamentos= ()=>{
        let options = [];
        this.state.departamentos.map((departamento, index)=>{
            options.push(<option key={index} value={departamento.Numero}>{departamento.Nombre}</option>)
        })
        return(options);
    }
    
    CreateOficios = (oficio)=>{    
        this.state.childComponents.push(<Oficios 
                                            oficio={oficio} 
                                            GetOficios={this.GetOficios} 
                                            index_father={this.state.childComponents.length}
                                        />);
        this.setState({
            childComponents : this.state.childComponents
        })
    }

    CreateSalarios = (salario)=>{    
        this.state.childComponents.push(<Salarios 
                                            salario={salario} 
                                            GetSalarios={this.GetSalarios} 
                                            index_father={this.state.childComponents.length} 
                                        />);
        this.setState({
            childComponents : this.state.childComponents
        });
    }

    DeleteChildComponent = (index)=>{
        this.state.childComponents.splice(index,1)
        this.setState({
            childComponents : this.state.childComponents
        })
    }

    ListEmpleados = ()=>{
        let tbody = [];
        this.state.empleados.map((empleado, index) => {   
            let cells = [];
            Object.keys(empleado).forEach((key, valueIndex) => {
                let cell = null
                cell = <td key={valueIndex}>{empleado[key]}</td>;    

                if(key === "oficio")
                    cell = <td key={valueIndex} onClick={() => this.CreateOficios(empleado[key])}>{empleado[key]}</td>;   
                
                if(key === "salario")
                    cell = <td key={valueIndex} onClick={() => this.CreateSalarios(empleado[key])}>{empleado[key]}</td>;   
                
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
            <p></p>
            <table border={1}> 
                <tbody>
                    {this.ListEmpleados()}
                </tbody>
            </table>
            {
                this.state.childComponents.map((component, index)=>{
                    
                    return(<div key={index}>
                            <button onClick={()=>this.DeleteChildComponent(index)}>Cerrar</button>
                            {component}
                        </div>);
                })
            }
        </div>);
    }
}