import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useParams, NavLink } from 'react-router-dom';
import {Component} from 'react';
import axios from 'axios';
import Home from "./Home";
import Globals from "../Globals";
import Doctores from "./Doctores/Doctores";

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
                            <a className="nav-link dropdown-toggle" href="/"  role="button" data-bs-toggle="dropdown" aria-expanded="false">
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
                            </ul>
                            </li>
                        </ul>
                        </div>
                    </div>
                </nav>
                <Routes>
                    <Route path="/" element={<Home/>}/>
                    <Route path="/hospital/:idhospital" element={<RedirectDoctores/>}/>
                </Routes>
            </BrowserRouter>
        )
    }

}