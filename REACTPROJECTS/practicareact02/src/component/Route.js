import Mulltiplicacion from "./Multiplicacion";
import Collatz from "./Collatz";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Component } from 'react';  

export default class Router extends Component {
	render() {
        return(
        <BrowserRouter>
        <Routes>        
            <Route path="/Mulltiplicacion" element={<Mulltiplicacion />} />
            <Route path="/Collatz" element={<Collatz />} />         
        </Routes>
      </BrowserRouter>
        )
	}
}  