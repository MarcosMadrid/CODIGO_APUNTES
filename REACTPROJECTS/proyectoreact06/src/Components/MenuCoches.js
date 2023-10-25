import {Component, createRef} from 'react';
import { NavLink } from 'react-router-dom';
import Swal from 'sweetalert2';
import axios from 'axios';
import Globals from '../Globals';
import './MenuCoches.css';


export default class MenuCoches extends Component{

  dropdown_list = createRef();
  input_coches = createRef();

  state={
    coches: [],
    datalist : []
  }

  GET_Coches=()=>{
    var request = 'api/coches'
    axios.get(Globals.urlCochesAPI + request).then(response=>{
        this.setState({
            coches: response.data
        });
    }).catch(error=>{
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Something went wrong!',
            footer: error.message
        });
    });
  }

  Render_DataListCoches=(event)=>{
    event.preventDefault();
    this.GET_Coches();

    var input = this.input_coches.current;
    var search = input.value;

    this.state.coches.filter(car => {   
      return Object.values(car).some(value => {
        if (typeof value === 'string') {
          return value.toLowerCase().includes(search);
        } else if (typeof value === 'number') {
          return value.toString().includes(search);
        }
        return false;
      });
    }); 

    this.state.datalist=[];
    this.state.coches.map((coche,index)=>{
      this.state.datalist.push(<li key={index}>
        <div class="card" >
            <div class="row g-0">
              <div class="col-md-4">
                <img src={coche.imagen} class="img-fluid rounded-start" width={input.clientWidth} height={input.height} alt="..."/>
              </div>
              <div class="col-md-8">
                <div class="card-body">
                  <h5 class="card-title">{coche.modelo}</h5>
                  <p class="card-text"><small>{coche.marca}</small></p>
                  <p class="card-text"><small class="text-body-secondary">{coche.conductor}</small></p>
                </div>
              </div>
            </div>
          </div>
          </li>
      );
    });

    this.dropdown_list.current.style.height = input.style.height;
    this.dropdown_list.current.style.width = input.style.clientWidth; 
    this.dropdown_list.current.style.left = input.style.left;
    this.dropdown_list.current.style.top = input.style.top + input.style.height;

    this.setState({
      datalist : this.state.datalist
    });
  }

  render(){
      return(
      <nav className="navbar navbar-expand-lg bg-body-tertiary">
      <div className="container-fluid ">
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
              <NavLink className="nav-link" to="/coches/añadir/">Añadir</NavLink>
            </li>
          </ul>
          <form className="d-flex" role="search">
            <input className="form-control me-2" ref={this.input_coches} onChange={(input_event)=>this.Render_DataListCoches(input_event)} type="search" placeholder="Search Coche" aria-label="Search"/>              
            <button className="btn btn-outline-success" type="submit">Search</button>
          </form>
          <div id="dropdown_list" style={{ zIndex: 1000 }} ref={this.dropdown_list}>
            <ul id='list_coches' className="list-unstyled ">
              {this.state.datalist}
            </ul>
          </div>          
        </div>
      </div>
    </nav>
    )}
}