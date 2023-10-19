import { Component } from "react";
import Global from "../../Global";
import "./EmpleadosComponents.css";

export default class Salarios extends Component{s
    urlApiEmpleados = Global.urlApiEmpleados;
    salario = this.props.salario;
    index_father = this.props.index_father;
    state={
        empleados_salario : []
    }
   

    ListEmpleadosSalarios = ()=>{
        let tbody = [];
        this.state.empleados_salario.map((empleado, index) => {   
            let cells = [];
            Object.keys(empleado).forEach((key, valueIndex) => {
                var cell = <td key={valueIndex}>{empleado[key]}</td>;         
                cells.push(cell);
            });  
            let row = (<tr key={index}><td>{index}</td>{cells}</tr>);
            tbody.push(row);
        });
        return(tbody)
    }

    componentWillMount= ()=>{         
        this.props.GetSalarios(this.salario)
        .then(data => {
          this.setState({ empleados_salario: data });
        })
        .catch(error => {
          console.error('Error fetching data:', error);
        });   
    }

    render(){
        return(            
            <table border={1}> 
                <tbody>
                    {this.ListEmpleadosSalarios()}
                </tbody>
            </table>
            );
    }
}