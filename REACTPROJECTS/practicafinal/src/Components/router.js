import {Component} from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from './home';
import MenuHospitales from './MenuHospitales';
import Hospitales from './Hospitales';

export default class Router extends Component{
    render(){
        return(<BrowserRouter>
            <MenuHospitales/>
            <Routes>
                <Route path='/' element={<Home/>}/>
                <Route path='/hospitales/' element={<Hospitales/>}/>
            </Routes>
        </BrowserRouter>);
    }
}