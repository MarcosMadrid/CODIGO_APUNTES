import { Component } from "react";
import Global from "../../Global";
import "./EmpleadosComponents.css";

export default class Oficios extends Component{
    urlApiEmpleados = Global.urlApiEmpleados;
    oficio = this.props.oficio;
    index_father = this.props.index_father;
    state={
        empleados_oficio : []
    };
   

    ListEmpleadosOficios = ()=>{
        let tbody = [];
        this.state.empleados_oficio.map((empleado, index) => {   
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
        this.props.GetOficios(this.oficio)
        .then(data => {
          this.setState({ empleados_oficio: data });
        })
        .catch(error => {
          console.error('Error fetching data:', error);
        });   
    }

    render(){
        return(
            <table border={1}> 
                <tbody>
                    {this.ListEmpleadosOficios()}
                </tbody>
            </table>
            );
    }
}