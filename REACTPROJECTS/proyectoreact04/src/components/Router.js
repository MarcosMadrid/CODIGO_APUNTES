import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useParams, NavLink } from 'react-router-dom';
import {Component} from 'react';
import axios from 'axios';
import Home from "./Home";
import Globals from "../Globals";
import Doctores from "./Doctores/Doctores";
import DetallesDoctores from "./Doctores/DetallesDoctores";
import AyadirHospital from "./Hospitales/AyadirHospital";
import Hospitales from "./Hospitales/Hospitales";

export default class Router extends Component{
    urlHospitalesAPI = Globals.urlHospitalesAPI;

    state ={
        hospitales : []
    }

    GetHospitales = ()=>{
        let request = "/webresources/hospitales";
        axios.get(this.urlHospitalesAPI + request).then(response=>{
            this.setState({
                hospitales : response.data
            });
        });
    }    

    componentDidMount = ()=>{
        this.GetHospitales();
    }

    render(){

        function RedirectDoctores(){
            let {idhospital} = useParams();
    
            return(<Doctores idhospital={idhospital}/>);
        }

        function RedirectDetallesDoctor(){
            let {id_doctor} = useParams();

            return(<DetallesDoctores id_doctor={id_doctor}/>)
        }

        function RedirectAyadirDoctor(){
            return(<AyadirHospital/>)
        }

        function RedirectHospitales(){
            return(<Hospitales/>)
        }

        return(
            <BrowserRouter>        
                <nav className="navbar navbar-expand-lg bg-body-tertiary">
                    <div className="container-fluid">
                        <NavLink className="navbar-brand" to="/">Home</NavLink>
                        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="collapse navbar-collapse" id="navbarNavDropdown">
                            <ul className="navbar-nav">
                                <li className="nav-item dropdown">
                                <a className="nav-link dropdown-toggle" href="/" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    Lista Hospitales
                                </a>
                                <ul className="dropdown-menu">
                                    {
                                        this.state.hospitales.map((hospital, index)=>{
                                            return(<li key={index}>
                                                <NavLink 
                                                    className = "dropdown-item" 
                                                    to = {"/hospital/"+hospital.idhospital}>
                                                    {hospital.nombre.toUpperCase()}
                                                </NavLink>
                                            </li>);
                                        })
                                    }
                                    <li><hr className="dropdown-divider"/></li>
                                    <li><NavLink className="dropdown-item" to="/hospitales">Ver Hospitales</NavLink></li>          
                                </ul>
                                </li>
                            </ul>
                            <a className="nav-link" href="/hospital/añadir/">
                                AñadirDoctor
                            </a>                                                                                      
                        </div>
                    </div>
                </nav>
                <Routes>
                    <Route path="/" element={<Home/>}/>
                    <Route path="/hospital/:idhospital" element={<RedirectDoctores/>}/>
                    <Route path="/doctor/detalles/:id_doctor" element={<RedirectDetallesDoctor/>}/>
                    <Route path="/hospital/añadir/" element={<RedirectAyadirDoctor/>}/>
                    <Route path="/hospitales" element={<RedirectHospitales/>}/>
                </Routes>
            </BrowserRouter>
        )
    }

}