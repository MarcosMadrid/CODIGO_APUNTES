import { Component } from "react";
import Globals from "../../Globals";
import axios from "axios";
import Swal from 'sweetalert2'

export default class CocheDetalles extends Component{
    urlCochesAPI = Globals.urlCochesAPI;
    state={
        coche : []
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

    RenderCoche = ()=>{
        var data_coche = [];
        Object.keys(this.state.coche).map((key,index_key)=>{
            data_coche.push(
                <div key={index_key} className="d-flex text-muted pt-3">                    
                    <p className="pb-3 mb-0 small lh-sm border-bottom">
                        <strong className="d-block text-gray-dark" >{key.toUpperCase()}</strong>
                        <li>{Object.values(this.state.coche)[index_key]}</li>
                    </p>
                </div>
            )
        });
        return(data_coche);
    }

    componentDidMount=()=>{
        this.Get_Coche();
    }

    render(){
        return(<div>
            <div className="d-flex align-items-center p-3 my-3 text-white bg-red rounded shadow-sm">
                <img className="me-3" src={this.state.coche.imagen} alt="" width="78" height="78"/>
                <div className="lh-1">
                <h1 className="h6 mb-0 text-white lh-1">{this.state.coche.modelo}</h1>
                <small>{this.state.coche.marca}</small>
                </div>
            </div>     

            <div className="my-3 p-3 d-block mx-auto rounded shadow-sm">
                <h6 className="border-bottom pb-2 mb-0">Datos del coche</h6>
                {this.RenderCoche()}                
            </div>  
        </div>);
    }
}