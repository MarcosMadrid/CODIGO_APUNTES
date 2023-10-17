import { Component } from "react";

class Deporte extends Component{

    state={
        deporte_state: this.props.deporte
    }

    deporte = this.state.deporte_state;

    deporte_input = "";


    setDeporte(e){
        this.deporte = e.target.value;
    }

    Modificar(key){
        this.setState({
            deporte: this.deporte
        });
        this.props.modificardeporte(this.deporte, key);
    }

    Eliminar(key){
        this.props.eliminardeporte(key);
    }

    
    render(){
        return(
        <div>
            <li key={this.props.index}>{this.deporte}</li>
            <input placeholder={this.deporte} onChange={(e) => this.setDeporte(e)}/>
            <button onClick={() => this.Modificar(this.props.index)} >Modificar</button>
            <button onClick={() => this.Eliminar(this.props.index)} >Eliminar</button>
        </div>
    )}

}

export default Deporte;