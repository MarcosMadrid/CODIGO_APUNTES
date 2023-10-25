import { Component } from "react";
import Globals from "../../Globals";
import axios from "axios";
import Swal from 'sweetalert2'


export default class CocheEliminar extends Component{
    urlCochesAPI = Globals.urlCochesAPI;

    state={
        coche:null
    }

    Get_Coche=()=>{
        var request = 'api/coches/findcoche/' + this.props.id_coche;
        axios.get(this.urlCochesAPI + request).then(response=>{
            this.setState({
                coche : response.data
            });
        }).catch(error=>{
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!',
                footer: error.message,
            });
        });
    }

    Delete_Coche=()=>{
        var request = 'api/Coches/DeleteCoche/' + this.state.coche.idCoche;
        axios.delete(this.urlCochesAPI + request).then(response=>{
            Swal.fire({
                icon: 'success',
                title: 'Eliminado',
                text: 'Se ha eliminado el coche:' + this.state.coche.idCoche
            }).then(function(){
               window.location.replace(window.location.host);
            });
        }).catch(error=>{
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!',
                footer: error.message,
            });
        });
    }

    Btn_Delete=(e)=>{
        e.preventDefault();
        Swal.fire({
            title: 'Desea eliminar el coche?',
            showDenyButton: true,
            confirmButtonText: 'Abortar',
            denyButtonText: `Eliminar`,
          }).then((result) => {
            if (result.isDenied) {
              this.Delete_Coche();
            }
          });
    }

    componentDidMount = ()=>{
        this.Get_Coche();
    }
    
    render(){
        if(this.state.coche === null ){
            return(<div>Coche vacio</div>)
        }
        return(<div>
            <div className="col-md-5 col-lg-4 d-block mx-auto order-md-last">
                <h4 className="d-flex justify-content-between align-items-center mb-3">
                    <span className="text-primary">Your cart</span>
                    <span className="badge bg-primary rounded-pill">ID {this.state.coche.idCoche}</span>
                </h4>
                <ul className="list-group mb-3">                   
                {
                    Object.keys(this.state.coche).map((key, index_key)=>{
                        return( 
                            <li key={index_key} className="list-group-item d-flex justify-content-between lh-sm">
                                <div>
                                    <h6 className="my-0">{key.toUpperCase()}</h6>                    
                                </div>
                                <span className="text-muted">{Object.values(this.state.coche)[index_key]}</span>
                            </li>);
                    })
                }                                       
                </ul>
                <form className="card p-1">                    
                    <button type="submit" onClick={this.Btn_Delete} className="btn btn-danger">Eliminar Coche</button>                   
                </form>
            </div>
        </div>);
    }
}