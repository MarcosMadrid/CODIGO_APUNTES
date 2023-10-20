import { Component } from "react";
import "./Home.css";

export default class Home extends Component{
    render(){
        return( 
                <div id="menu">
                    <ul>
                        <li><a href="Collatz/14">Colatz 14</a></li>
                    </ul>       
                </div>
        )
    }
}