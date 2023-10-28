import {Component} from 'react';
import axios from 'axios';
import Globals from '../Globals';
import  {NavLink} from 'react-router-dom';

export default class MenuApuestas extends Component{
    urlApuestasAPI = Globals.urlApuestasAPI;

    state = {
        equipos : []
    }
    
    GET_Jugadores=()=>{
        var request = '/api/equipos/';
        axios.get(this.urlApuestasAPI + request).then(response =>{
            this.setState({
                equipos : response.data
            })
        }).catch(error=>{

        });
    }

    OptionsEquipos = ()=>{
        if( this.state.equipos.length === 0)
            return;
        var options = []
        this.state.equipos.map((equipo, index)=>{
            options.push(<li key={index}>
                    <NavLink className="dropdown-item" to={'/equipos/'+equipo.idEquipo}>{equipo.nombre}</NavLink>
                </li>);
        });
        return(options);
    }

    componentDidMount = ()=>{
        this.GET_Jugadores();
        setInterval(this.GET_Jugadores, 10000);
    }

    render(){
        return(
        <nav className="navbar navbar-expand-lg bg-body-tertiary">
            <div className="container-fluid">
                <NavLink className="navbar-brand" to="/">Home</NavLink>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav">
                        <li className="nav-item">
                            <NavLink className="nav-link" to="/apuestas/">Apuestas</NavLink>
                        </li>
                        <li className="nav-item dropdown">
                            <a className="nav-link dropdown-toggle" href="/equipos/" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                Equipos
                            </a>
                            <ul className="dropdown-menu">
                                {this.OptionsEquipos()}
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>      
        )
    }
}