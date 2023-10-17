import { Component } from "react";

function LeerContador(element){
    console.log(element.numero);
}

class Contador extends Component {
    
    state={
        valor: parseInt(this.props.inicio)
    };

    numero = this.state.valor;


    setNumero = () => {
        this.setState({
            valor: this.state.valor + 1
        })
        this.numero = this.state.valor;
    }

    render(){
        return(
            <div>
                <h1>Class Contador</h1>
                <h2> Inicio {this.props.inicio}</h2>

                <button onClick={this.setNumero}>
                    Incrementar número
                </button>

                <h3>Contador: {this.numero}</h3>
                {LeerContador(this)}
            </div>
        )
    }
}

export default Contador;