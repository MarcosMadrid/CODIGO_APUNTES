import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useParams} from 'react-router-dom';
import {Component} from 'react';
import Home from "./Home";
import "bootstrap/dist/css/bootstrap.min.css";
import 'bootstrap/dist/js/bootstrap.bundle';
import MenuDepartamentos from "./Departamentos/MenuDepartamentos";
import Departamentos from "./Departamentos/Departamentos";
import AyadirDepartamento from "./Departamentos/AyadirDepartamento";
import DetallesDepartamento from "./Departamentos/DetallesDepartamento";

export default class Router extends Component{
    render(){

        function RedirectDepartamentos(){
            return(<Departamentos/>);
        }

        function RedirectAyadirDepartamento(){
            return(<AyadirDepartamento/>);
        }

        function RedirectDetallesDepartamento(){
            var {numero} = useParams();
            return(<DetallesDepartamento iddepartamento={numero}/>);
        }

        return(<div>  
            <BrowserRouter>
            <MenuDepartamentos/>
                <Routes>
                    <Route path="/" element={<Home/>}/>
                    <Route path="/departamentos" element={<RedirectDepartamentos/>}/>
                    <Route path="/departamentos/añadir" element={<RedirectAyadirDepartamento/>}/>
                    <Route path="/departamento/:numero" element={<RedirectDetallesDepartamento/>}/>
                </Routes>
            </BrowserRouter>
        </div>);
    }
}