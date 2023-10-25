import {Component} from 'react';
import axios from 'axios';
import Globals from '../../Globals';
import Swal from 'sweetalert2';
import { Navigate } from 'react-router-dom';
import DetallesDepartamento from './DetallesDepartamento';

export default class EliminarDepartamento extends Component{
    urlDepartamentosAPI = Globals.urlDepartamentosAPI;

    Delete_Departamento(){
        var request = 'api/departamentos/' + parseInt(this.props.iddepartamento);
        Swal.fire({
            title: 'Desea eliminar el departamento: '+ this.props.iddepartamento +'? ',
            showDenyButton: true,
            showCancelButton: false,
            confirmButtonText: 'Confirmar',
            denyButtonText: `Cancelar`,
          }).then((result) => {
            if(result.isConfirmed){
              axios.post(this.urlDepartamentosAPI + request).then(response=>{
                  Swal.fire({
                      icon: 'success',
                      title: 'Departamento Eliminado', 
                    }).then(function(){
                        return(<Navigate to="/departamentos/"/>)
                    })
                }).
                catch(error => {
                    console.log(error)
                    Swal.fire({
                        icon: 'error',
                        title: 'Error al eliminar departamento:' + this.props.iddepartamento,
                        text: error.message,
                    });
                })      
            }else{
                return(<Navigate to="/departamentos/"/>);
            }
        })
    }

    render(){
        return(<div>
            <DetallesDepartamento iddepartamento={this.props.iddepartamento}/>
            <button className='btn btn-danger' onClick={this.Delete_Departamento()}>Eliminar</button>
        </div>);
    }
}