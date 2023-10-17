import { Component } from "react";

function setListCoches(numeros){
    let list_num = [];
    for (let index = 0; index < numeros.length; index++) {
        list_num.push(<li key={index}>{numeros[index]}</li>)        
    }
    return(list_num);
}
class DibujosComplejos extends Component{


    state={
        numeros_state: []
    }    

    numeros = []

    setNumero = ()=>{
        var numero = parseInt(Math.random()*100);
        this.setState({
            numeros: this.state.numeros_state.push(numero)
        });

        this.numeros = this.state.numeros_state;
    }


    render(){
        return(
           
            <div>
                <h1>Lista compleja React</h1>
                <button onClick={this.setNumero}>Crear numero</button>
            <ul>
                {
                    this.numeros.map((numero,index)=>{
                        return(<li key={index}>{numero}</li>);
                    })
                }
                <hr></hr>

                {setListCoches(this.numeros)}
            </ul>
            </div>
        )
    }
}

export default DibujosComplejos;