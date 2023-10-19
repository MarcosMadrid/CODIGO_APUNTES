import { Component } from "react";
import "./Home.css";

export default class Home extends Component{
    render(){
        return( 
                <div id="menu">
                    <ul>
                        <li><a href="ServiceCustomers">ServiceCustomers</a></li>
                        <li><a href="ServiceCoches">ServiceCoches</a></li>
                        <li><a href="ServiceEmpleadosDepartamentos">ServiceEmpleadosDepartamentos</a></li>
                    </ul>       
                </div>
        )
    }
}