import {Component} from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useParams} from 'react-router-dom';
import Home from './Home';
import MenuCoches from './MenuCoches';
import Coches from './Coches/Coches';
import CocheDetalles from './Coches/CocheDetalles';
import CocheEliminar from './Coches/CocheEliminar';
import CocheModificar from './Coches/CocheModificar';
import CocheAyadir from './Coches/CocheAyadir';

export default class Router extends Component{
    render(){
        function Redirect_Home(){
            return(<Home/>);
        }

        function Redirect_Coches(){
            return(<Coches/>);
        }

        function Redirect_CocheDetalles(){
            var {id_coche} = useParams();
            return(<CocheDetalles id_coche={id_coche}/>);
        }

        function Redirect_CocheEliminar(){
            var {id_coche} = useParams();
            return(<CocheEliminar id_coche={id_coche}/>);
        }

        function Redirect_CocheModificar(){
            var {id_coche} = useParams();
            return(<CocheModificar id_coche={id_coche}/>);
        }

        function Redirect_CocheAyadir(){
            return(<CocheAyadir/>);
        }

        return(<BrowserRouter>
            <MenuCoches/>
            <Routes>
                <Route path='/' element={<Redirect_Home/>}/>
                <Route path='/coches/' element={<Redirect_Coches/>}/>
                <Route path='/coches/:id_coche' element={<Redirect_CocheDetalles/>}/>
                <Route path='/coches/eliminar/:id_coche' element={<Redirect_CocheEliminar/>}/>
                <Route path='/coches/modificar/:id_coche' element={<Redirect_CocheModificar/>}/>
                <Route path='/coches/añadir/' element={<Redirect_CocheAyadir/>}/>
            </Routes>
        </BrowserRouter>);
    }
}