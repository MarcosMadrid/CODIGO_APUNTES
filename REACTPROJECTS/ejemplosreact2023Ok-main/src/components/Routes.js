import Comics from './Comics';
import Contador from './Contador';
import SumarNumeros from './SumarNumeros/SumarNumeros';
import SaludoPadre from './SaludoPadre';
import PadreMatematicas from './PadreMatematicas';
import Car from './Car';
import DibujosComplejos from './DibujosComplejos';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Component } from 'react';  

export default class Router extends Component {
	render() {
        return(
        <BrowserRouter>
        <Routes>        
            <Route path="/Comics" element={<Comics />} />
            <Route path='/Contador' element={<Contador />} />
            <Route path="/SumarNumeros" element={<SumarNumeros />} />
            <Route path="/PadreMatematicas" element={<PadreMatematicas />} />
            <Route path="/Car" element={<Car />} />
            <Route path="/SaludoPadre" element={<SaludoPadre />} />
            <Route path="/DibujosComplejos" element={<DibujosComplejos />} />         
        </Routes>
      </BrowserRouter>
        )
	}
}  