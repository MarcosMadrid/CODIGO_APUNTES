import axios from "axios";
import { Component, createRef } from "react";
import Globals from "../../Globals";
import Swal from "sweetalert2";

export default class ModificarDepartamento extends Component{
    urlDepartamentosAPI = Globals.urlDepartamentosAPI;

    Input_nombre = createRef();
    Input_nombre = createRef();
    Input_localidad = createRef();

    state={
        departamento : null
    }

    Get_Departamento= ()=>{
        var request = 'api/departamentos/' + this.props.iddepartamento;
        axios.get(this.urlDepartamentosAPI + request).then(response=>{
            this.setState({
                departamento : response.data
            })
        }).catch(error=>{
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: error.message,
            });
        })
    }

    Update_Departamento = (departamento)=>{
        var request = 'api/departamentos/'+this.props.iddepartamento;
        axios.post(this.urlDepartamentosAPI + request , departamento).then(response=>{
            this.setState({
                departamento : response.data,
            })
        }).
        catch(error=>{
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: error.message,
            });
        });
    }

    Submit_Departamento= (e)=>{
        e.preventDefault();

        var departamento ={
            numero : this.props.iddepartamento,
            nombre : this.Input_nombre.current.value,
            localidad : this.Input_localidad.current.value
        }
        
        this.Update_Departamento(departamento);
    }


    componentDidMount = ()=>{
        this.Get_Departamento();        
    }

    render(){

        if(this.state.departamento === null){
            return(<div>None</div>);
        }else{
            return(<div>            
                <form>
                    <div className="mb-3">
                        <label htmlFor="formGroupExampleInput" className="form-label">NUMERO</label>
                        <input type="text" className="form-control" ref={this.Input_numero} value={this.state.departamento.iddepartamento} id="Input_numero" placeholder={this.props.iddepartamento} readOnly/>
                    </div>
                    <div className="mb-3">
                        <label htmlFor="formGroupExampleInput2" className="form-label">NOMBRE</label>
                        <input type="text" className="form-control" ref={this.Input_nombre} defaultValue={this.state.departamento.nombre} id="Input_nombre" placeholder="Another input placeholder" />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="formGroupExampleInput" className="form-label">LOCALIDAD</label>
                        <input type="text" className="form-control" ref={this.Input_localidad} defaultValue={this.state.departamento.localidad} id="Input_localidad" placeholder="Example input placeholder"/>
                    </div>
                    <button className='btn btn-primary' onClick={this.Submit_Departamento}>Insertar Departamento</button>
                </form>
            </div>);
        }
    }
}