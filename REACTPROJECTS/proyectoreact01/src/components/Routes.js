import { BrowserRouter, Routes, Route } from "react-router-dom";
import ServiceCustomers from "./ServiceCustomers";
import ServiceCoches from "./ServiceCoches";
import { Component } from 'react';  
import ServiceEmpleadosDepartamentos from "./ServiceEmpleadosDepartamentos";

export default class Router extends Component{

    render(){
        return(
            <BrowserRouter>
                <Routes>
                    <Route path="ServiceCustomers" element={<ServiceCustomers/>} />
                    <Route path="ServiceCoches" element={<ServiceCoches/>} />
                    <Route path="ServiceEmpleadosDepartamentos" element={<ServiceEmpleadosDepartamentos/>} />
                </Routes>
            </BrowserRouter>
        )
    }
}