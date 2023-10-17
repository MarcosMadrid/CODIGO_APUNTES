import Deporte from "./Deporte";
import { Component, createRef } from "react"


class Deportes extends Component {
    constructor(props){
        super(props);
        this.input_añadir = createRef();
    }

    state ={
        deportes : ["tenis", "pinpon", "futbol" , "baloncesto"]
    }
    
    UpdateDeporte = (deporte, index) =>{
        this.state.deportes[index] = deporte;
        this.setState({
            deportes : this.state.deportes
        });
    }

    DeleteDeporte = (index) =>{
        this.state.deportes.splice(index,1);
        console.log(this.state.deportes)
        this.setState({
            deportes : this.state.deportes
        });        
    }

    CreateDeporte = () =>{
        var deporte = this.input_añadir.current.value;
        this.state.deportes.push(deporte);
        this.setState({
            deportes : this.state.deportes
        });
    }

    render(){
    return (
        <div>
            <h1>Deportes</h1>
            <input placeholder="Crear deporte" ref={this.input_añadir}></input>
            <button onClick={()=> this.CreateDeporte()}>Añadir deporte</button>
            <ul>{                
                this.state.deportes.map((deporte,index) => {
                    console.log(this.state.deportes)
                    return (<Deporte deporte={deporte} key={index} index={index} modificardeporte={this.UpdateDeporte} eliminardeporte={this.DeleteDeporte} />)
                })
                }
            </ul>
        </div>
    )};
}

export default Deportes;