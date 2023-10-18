import { Component } from "react";
import "./Home.css";

export default class Home extends Component{
    render(){
        return( 
                <div id="menu">
                    <ul>
                        <li><a href="Mulltiplicacion">Mulltiplicacion</a></li>
                        <li><a href="Collatz">Collatz</a></li>
                    </ul>       
                </div>
        )
    }
}