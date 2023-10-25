import {Component} from 'react';
import { NavLink } from 'react-router-dom';


export default class MenuCoches extends Component{
    render(){
        return(
        <nav className="navbar navbar-expand-lg bg-body-tertiary"  >
        <div className="container-fluid">
          <NavLink className="navbar-brand" to={'/'}>Home</NavLink>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <NavLink className="nav-link" aria-current="page" to={"/coches/"}>Coches</NavLink>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="#">Añadir</a>
              </li>
            </ul>
            <form className="d-flex" role="search">
              <input className="form-control me-2" type="search" placeholder="Search Coche" aria-label="Search"/>
              <button className="btn btn-outline-success" type="submit">Search</button>
            </form>
          </div>
        </div>
      </nav>
      )}
}