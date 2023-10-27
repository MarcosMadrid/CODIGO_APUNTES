import {Component} from 'react';

export default class InputSalario extends Component{


    render(){
        return(<div>
            <input></input>
            <button onClick={()=>{this.props.GET_TrabajadoresHospital()}}>Botoncito</button>
        </div>);
    }
}