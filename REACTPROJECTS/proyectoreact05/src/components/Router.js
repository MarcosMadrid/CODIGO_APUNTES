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
import EliminarDepartamento from "./Departamentos/EliminarDepartamento";
import ModificarDepartamento from "./Departamentos/ModificarDepartamento";

export default class Router extends Component{
    render(){

        function Redirect_Departamentos(){
            return(<Departamentos/>);
        }

        function Redirect_AyadirDepartamento(){
            return(<AyadirDepartamento/>);
        }

        function Redirect_DetallesDepartamento(){
            var {numero} = useParams();
            return(<DetallesDepartamento iddepartamento={numero}/>);
        }

        function Redirect_EliminarDepartamento(){
            var {numero} = useParams();
            return(<EliminarDepartamento iddepartamento={numero}/>);
        }

        function Redirect_ModificarDepartamento(){
            var {numero} = useParams();
            return(<ModificarDepartamento iddepartamento={numero}/>);
        }

        return(<div>  
            <BrowserRouter>
            <MenuDepartamentos/>
                <Routes>
                    <Route path="/" element={<Home/>}/>
                    <Route path="/departamentos" element={<Redirect_Departamentos/>}/>
                    <Route path="/departamentos/añadir" element={<Redirect_AyadirDepartamento/>}/>
                    <Route path="/departamento/:numero" element={<Redirect_DetallesDepartamento/>}/>
                    <Route path="/departamento/eliminar/:numero" element={<Redirect_EliminarDepartamento/>}/>
                    <Route path="/departamento/modificar/:numero" element={<Redirect_ModificarDepartamento/>}/>
                </Routes>
            </BrowserRouter>
        </div>);
    }
}