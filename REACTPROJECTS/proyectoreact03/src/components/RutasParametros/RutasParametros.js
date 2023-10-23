import {Component} from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useParams, NavLink } from 'react-router-dom';
import Collatz from '../Collatz/Collatz';

export default class RutasParametros extends Component{

    render(){
        function CollatzParamsUrl(){
            var {numero} = useParams();            

            return(<Collatz numero={numero}/>)
        }
        return(
            
            <BrowserRouter>
            <h1>TITULO</h1>
            <nav className="navbar navbar-expand-lg bg-body-tertiary">
            <div className="container-fluid">
              <NavLink className="navbar-brand" to="/">Navbar</NavLink>
              <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
              </button>
              <div className="collapse navbar-collapse" id="navbarNav">
                <ul className="navbar-nav">
                  <li className="nav-item">
                    <NavLink className="nav-link active" aria-current="page"  to="/">Home/</NavLink>
                  </li>
                  <li className="nav-item">
                    <NavLink className="nav-link" to="/collatz/14">Colatz 14/</NavLink>
                  </li>
                  <li className="nav-item">
                    <NavLink className="nav-link" to="/">Pricing</NavLink>
                  </li>
                  <li className="nav-item">
                    <NavLink className="nav-link disabled" aria-disabled="true">Disabled</NavLink>
                  </li>
                </ul>
              </div>
            </div>
          </nav>   
                <Routes>
                    <Route path='/collatz/:numero' element={<CollatzParamsUrl/>}/>
                </Routes>
            </BrowserRouter>
        )
    }
}