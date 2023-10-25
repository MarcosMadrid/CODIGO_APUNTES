import {Component} from 'react';
import axios from 'axios';
import Globals from './../../Globals';
import Loading_img from '../../assets/imgs/loading-gif-png-5.gif';
import  {NavLink} from 'react-router-dom';


export default class Departamentos extends Component{
    urlDepartamentosAPI = Globals.urlDepartamentosAPI;

    state={
        departamentos : null
    }

    Get_Departamentos= ()=>{
        var request = '/api/departamentos';
        axios.get(this.urlDepartamentosAPI + request).then(response=>{
            this.setState({
                departamentos: response.data
            });
            console.log(response.data)
        });
    }

    componentDidMount = ()=>{
        this.Get_Departamentos();
    }

    render(){

        if(this.state.departamentos === null){
            return(<img src={Loading_img} width={"120px"} height={"200px"} />);
        }else{
            return(<div>            
                <table className="table">
                    <thead>
                        <tr>
                        {
                            this.state.departamentos.length !== 0 &&                           
                                Object.keys(this.state.departamentos[0]).map((key_dept, index_key)=>{
                                    return(<th key={index_key}>{key_dept.toUpperCase()}</th>);
                                })                      
                        }
                        </tr>
                    </thead>
                    <tbody>
                        
                        {
                            this.state.departamentos.map((departamento, index_dept)=>{
                                var cells = [];
                                Object.values(departamento).map((value, index_value)=>{
                                    cells.push(<td key={index_value}>{value}</td>);
                                });
                                return(<tr key={index_dept}>{cells}

                                    <td><NavLink className='btn btn-primary'  to={"/departamento/" + departamento.numero}> Detalles </NavLink></td>
                                    <td><NavLink className='btn btn-danger'   to={"/departamento/eliminar/" + departamento.numero}> Eliminar </NavLink></td>
                                    <td><NavLink className='btn btn-info' to={"/departamento/modificar/" + departamento.numero}> Modificar </NavLink></td>

                                </tr>);
                            })
                        }                    
                
                    </tbody>
                    </table>
            </div>);
        }
    }
}