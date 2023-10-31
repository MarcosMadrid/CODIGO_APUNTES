import {Component} from 'react';
import { BrowserRouter, Routes, Route, useParams } from "react-router-dom";
import Apuestas from './Apuestas';
import MenuApuestas from './MenuApuestas';
import Home from './Home';
import CreateApuesta from './CreateApuesta';
import EquipoDetallesJugadores from './EquipoDetallesJugadores';
import EquipoDetalles from './EquipoDetalles';

export default class Router extends Component{
    render(){

        function Redirect_EquiposDetalles(){
            var {numero} = useParams();

            return(<EquipoDetalles id_equipo={numero} />)
        }

        function Redirect_EquiposDetallesJugadores(){
            var {numero} = useParams();

            return(<EquipoDetallesJugadores id_equipo={numero} />)
        }

        return(<BrowserRouter>
            <MenuApuestas/>
            <Routes>
                <Route path='/' element={<Home/>} />
                <Route path='/apuestas/' element={<Apuestas/>}/>
                <Route path='/apuesta/crear/' element={<CreateApuesta/>}/>
                <Route path='/equipos/:numero' element={<Redirect_EquiposDetalles/>}/>
                <Route path='/equipos/jugadores/:numero' element={<Redirect_EquiposDetallesJugadores/>}/>
            </Routes>
        </BrowserRouter>)
    }
}