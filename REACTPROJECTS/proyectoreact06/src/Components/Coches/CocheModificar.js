import { Component } from "react"

export default class CocheModificar extends Component{
    render(){
        return(<div>
            Modificar: {this.props.id_coche}
        </div>);
    }
}