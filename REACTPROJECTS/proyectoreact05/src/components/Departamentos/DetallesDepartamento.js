import {Component} from 'react';
import axios from 'axios';
import Globals from '../../Globals';
import Loading_img from '../../assets/imgs/loading-gif-png-5.gif';
import Swal from 'sweetalert2'

export default class DetallesDepartamento extends Component{
    urlDepartamentosAPI = Globals.urlDepartamentosAPI;
    state={
        departamento : null
    }

    Get_Departamento=()=>{
        var request = 'api/departamentos/'+ parseInt(this.props.iddepartamento);
        axios.get(this.urlDepartamentosAPI+ request).then(response=>{
            console.log(response)
            this.setState({
                departamento : response.data
            });
        }).
        catch(error => {
            console.log(error)
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: "Ha ocurrido un error /n" + error.message,
                });
            });          
    }

    componentDidMount = ()=>{
        this.Get_Departamento();
    }

    componentDidUpdate = (before)=>{
        if(before.iddepartamento !== this.props.iddepartamento)
            this.Get_Departamento();
    }

    render(){
        if(this.state.departamento === null){
            return(<img src={Loading_img} width={"120px"} height={"200px"} />);
        }else{
            return(<div>            
                <table className="table">
                    <thead>
                        <tr>
                        {                                                     
                            Object.keys(this.state.departamento).map((key_dept, index_key)=>{
                                return(<th key={index_key}>{key_dept.toUpperCase()}</th>);
                            })                      
                        }
                        </tr>
                    </thead>
                    <tbody>                        
                        <tr>
                        {                                                            
                            Object.values(this.state.departamento).map((value, index_value)=>{
                                return(<td key={index_value}>{value}</td>);
                            })                               
                        }
                        </tr>            
                    </tbody>
                    </table>
            </div>);
        }
    }
}