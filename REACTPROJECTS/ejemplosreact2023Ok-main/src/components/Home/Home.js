import { Component } from "react";
import "./Home.css";

export default class Home extends Component{
    render(){
        return( 
                <div id="menu">
                    <ul>
                        <li><a href="Comics">Comics</a></li>
                        <li><a href="Contador">Contadore</a></li>
                        <li><a href="SumarNumeros">SumarNumeros</a></li>
                        <li><a href="PadreMatematicas">PadreMatematicas</a></li>
                        <li><a href="Car">Car</a></li>
                        <li><a href="SaludoPadre">SaludoPadre</a></li>
                        <li><a href="DibujosComplejos">DibujosComplejos</a></li>
                    </ul>       
                </div>
        )
    }
}