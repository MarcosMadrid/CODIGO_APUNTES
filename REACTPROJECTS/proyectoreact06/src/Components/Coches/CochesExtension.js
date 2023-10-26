import { Component } from "react";
import { NavLink } from "react-router-dom";

export default class CocheExtension extends Component{

    state={
        coche: this.props.coche
    }

    componentDidUpdate = (before)=>{
        if(before.coche.idCoche !== this.props.coche.idCoche ){
            this.setState({
                coche : this.props.coche
            })
        }
    }

    render(){
        return(
            <div >
                <div className="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 ">
                    <div className="col p-4 d-flex flex-column position-static">
                        <strong className="d-inline-block mb-2 text-success-emphasis">
                        {this.state.coche.modelo} 
                        </strong>
                        <h3 className="mb-0">{this.state.coche.idCoche+ "-" + this.state.coche.marca[0] + this.state.coche.modelo[0]} </h3>
                        <div className="mb-1 text-body-secondary">{this.state.coche.conductor}</div>
                        <p className="mb-auto">{this.state.coche.marca}</p>   
                        <div className="btn-group">
                                <NavLink to={'/coches/' + this.state.coche.idCoche} className="btn btn-sm btn-primary">Detalles</NavLink>
                                <NavLink to={'/coches/eliminar/' + this.state.coche.idCoche} className="btn btn-sm btn-danger ">Eliminar</NavLink>
                                <NavLink to={'/coches/modificar/' + this.state.coche.idCoche} className="btn btn-sm btn-info ">Modificar</NavLink>    
                        </div>                     
                    </div>
                    <div className="col-auto d-lg-block">
                        <img className="bd-placeholder-img" src={this.state.coche.imagen} width="200" height="250" role="img" preserveAspectRatio="xMidYMid slice" focusable="false"/>
                    </div>
                </div>
            </div>
        )
    }
}
