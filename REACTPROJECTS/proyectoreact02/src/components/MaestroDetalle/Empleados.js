import { Component } from "react";

export default class Empleados extends Component{
    id_departamento = this.props.id_departamento;

    state = {   
        empleados : []
    }

    TableEmpleados= ()=>{
       let rows = [];
        this.state.empleados.map((empleado,index)=>{
            let cells = [];
            Object.values(empleado).forEach((value, i)=>{
                cells.push(<td>{value}</td>);
            });
            rows.push(<tr>{cells}</tr>);
            return(null);
        });
        return(rows);
    }

    componentWillMount = ()=>{
        this.props.GetEmpleadosDepartamento(this.id_departamento)
        .then(data => {
          this.setState({ empleados: data });
        })
        .catch(error => {
          console.error('Error fetching data:', error);
        });   
    }

    render(){
        return(<div>
            <h2>Empleados Component {this.id_departamento}</h2>
            <table>
                <tbody>
                    {this.TableEmpleados()}
                </tbody>
            </table>
        </div>);
    }
}