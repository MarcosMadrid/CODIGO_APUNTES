import { Component } from "react";
import Globals from "../Globals";
import axios from "axios";

export default class EquipoDetallesJugadores extends Component{
    urlApuestasAPI = Globals.urlApuestasAPI;
    
    state ={
        jugadores : []
    }

    GET_Equipo = ()=>{
        var request = '/api/jugadores/JugadoresEquipos/' + this.props.id_equipo;
        axios.get(this.urlApuestasAPI + request).then(response=>{
            this.setState({
                jugadores : response.data
            });
        }).catch(error=>{
            console.log(error.menssage);
        });
    }

    componentDidUpdate = (before)=>{
        if(before.id_equipo !== this.props.id_equipo)
            this.GET_Equipo();
    }

    componentDidMount = ()=>{
        this.GET_Equipo();
    }

    render(){
        if(this.state.jugadores.length === 0)
            return('');

        return(<div>
            <table className="table">
            <thead>
            </thead>
            <tbody>
                {
                    this.state.jugadores.map((jugador , index_jugador)=>{
                        var cells = [];
                        Object.values(jugador).map((value,index)=>{
                            if(Object.keys(jugador)[index] === 'imagen'){
                                cells.push(<td key={index} > <img src={value} alt={value} style={{width:"50px",height:"50px"}} /> </td>);
                            }else{                            
                                cells.push(<td key={index} > {value} </td>);
                            }
                        });
                        return(<tr key={index_jugador} >{cells}</tr>);
                    })
                }          
            </tbody>
        </table>
        </div>);
    }
}