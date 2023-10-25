import { Component } from "react";
import Globals from "../../Globals";
import axios from 'axios';
import Loading_img from './../../assets/imgs/loading-gif-png-5.gif';
import { NavLink } from "react-router-dom";

export default class Coches extends Component{
    urlCochesAPI = Globals.urlCochesAPI

    state={
        coches : null
    }

    GET_Coches=()=>{
        var request = 'api/coches'
        axios.get(this.urlCochesAPI + request).then(response=>{
            this.setState({
                coches: response.data
            })
            console.log(response.data)
        }).catch(error=>{
            console.log(error.message)
        });
    }

    Error_ImgCoche=(img)=>{
        var imagen = img.currentTarget;
        imagen.src = Loading_img;
    }

    Render_Coches=()=>{
        var cards_coches = [];

        this.state.coches.map((coche,index_coche)=>{
            cards_coches.push(
                <div className="col" key={index_coche}>
                <div className="card shadow-sm">
                    <img className="bd-placeholder-img card-img-top" width="100%" height="225" src={coche.imagen} onError={(img)=>{this.Error_ImgCoche(img)}} role="img" alt={coche.marca + " " + coche.modelo} preserveAspectRatio="xMidYMid slice" focusable="false"/>
                    <div className="card-body">
                        <p className="card-text">{coche.marca.toUpperCase()}</p>
                        <div className="d-flex justify-content-between align-items-center">
                            <div className="btn-group">
                                <NavLink to={'/coches/' + coche.idCoche} className="btn btn-sm ">Detalles</NavLink>
                                <NavLink to={'/coches/eliminar/' + coche.idCoche} className="btn btn-sm btn-danger ">Eliminar</NavLink>
                                <NavLink to={'/coches/modificar/' + coche.idCoche} className="btn btn-sm btn-info ">Modificar</NavLink>    
                            </div>
                            <small className="text-body-secondary">{coche.conductor}</small>
                        </div>
                    </div>
                </div>
            </div>    
            )
        }); 
        return(cards_coches)
    }

    componentDidMount = ()=>{
        this.GET_Coches();
    }
    
    render(){
        if(this.state.coches === null){
            return(<img src={Loading_img}/>)
        }else{
            return(<div className="album py-5 bg-body-tertiary">
                <div className="container">
                    <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">         
                            {this.Render_Coches()}       
                    </div>
                </div>                
            </div>);
        }
    }
}