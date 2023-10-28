import axios from "axios";
import { Component } from "react";
import Globals from "../Globals";
import { NavLink } from "react-router-dom";

export default class EquipoDetalles extends Component{
    urlApuestasAPI = Globals.urlApuestasAPI;

    state = {
        equipo : null
    }

    GET_Equipo = ()=>{
        var request = '/api/equipos/' + this.props.id_equipo;

        axios.get(this.urlApuestasAPI + request).then(response=>{
            this.setState({
                equipo : response.data
            });
        }).catch(error=>{
            console.log(error.message);
        });
    }

    componentDidMount = ()=>{
        this.GET_Equipo();
    }

    componentDidUpdate = (before)=>{
        if(before.id_equipo !== this.props.id_equipo)
            this.GET_Equipo();
    }


    render(){
        if(this.state.equipo === null)
            return('');

        return(<div>
             <section className="py-5 text-center container">
                <div className="row py-lg-5">
                    <div className="col-lg-6 col-md-8 mx-auto">
                        <img src={this.state.equipo.imagen} style={{width:"280px", height:"280px"}} alt={this.state.equipo.nombre.toUpperCase()} />
                        <h1 className="fw-light">{this.state.equipo.nombre.toUpperCase()}</h1>
                        <p className="text-sm-center">{this.state.equipo.descripcion.toUpperCase()}</p>
                    </div>
                    <NavLink  className="btn btn-primary" to={'/equipos/jugadores/'+this.state.equipo.idEquipo} aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm">
                        Jugadores
                    </NavLink>
                </div>
            </section>                             
                
        </div>);
    }
}