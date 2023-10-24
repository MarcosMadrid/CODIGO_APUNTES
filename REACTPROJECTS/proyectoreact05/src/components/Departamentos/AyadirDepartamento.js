import {Component} from 'react';
import Globals from '../../Globals';
import axios from 'axios';
import React from 'react';
import Swal from 'sweetalert2'
import { Navigate} from 'react-router-dom';

export default class AyadirDepartamento extends Component{
    urlDepartamentosAPI = Globals.urlDepartamentosAPI;
    Input_numero = React.createRef();
    Input_nombre = React.createRef();
    Input_localidad = React.createRef();

    Submit_Departamento = (e)=>{
        e.preventDefault();

        var departamento = {
            numero : parseInt(this.Input_numero.current.value),
            nombre : this.Input_nombre.current.value,
            localidad : this.Input_localidad.current.value
        }
        
        this.Post_Departamento(departamento);
    }

    Post_Departamento(departamento){
        var request = '/api/Departamentos';
        axios.post(this.urlDepartamentosAPI + request, departamento).then(response=>{            
            Swal.fire({
                icon: 'success',
                title: 'Departamento Añadido', 
                }).then(function(){
                    return(<Navigate to="/"/>)
                })
            }).
            catch(error => {
                console.log(error)
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: error.message,
                    });
                })       
    }


    render(){
        return(
        <form>
            <div className="mb-3">
                <label htmlFor="formGroupExampleInput" className="form-label">NUMERO</label>
                <input type="text" className="form-control" ref={this.Input_numero} id="Input_numero" placeholder="Example input placeholder"/>
            </div>
            <div className="mb-3">
                <label htmlFor="formGroupExampleInput2" className="form-label">NOMBRE</label>
                <input type="text" className="form-control" ref={this.Input_nombre} id="Input_nombre" placeholder="Another input placeholder"/>
            </div>
            <div className="mb-3">
                <label htmlFor="formGroupExampleInput" className="form-label">LOCALIDAD</label>
                <input type="text" className="form-control" ref={this.Input_localidad} id="Input_localidad" placeholder="Example input placeholder"/>
            </div>
            <button className='btn btn-primary' onClick={this.Submit_Departamento}>Insertar Departamento</button>
        </form>
        )
    }
}