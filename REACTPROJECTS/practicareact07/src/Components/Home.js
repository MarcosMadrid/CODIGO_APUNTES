import { Component } from "react";
import Globals from "../Globals";
import axios from "axios";

export default class Home extends Component {
    urlApuestasAPI = Globals.urlApuestasAPI;

    state ={
        jugadores : []
    }

    GET_JugadoresNombre = (search)=>{
        var request = '/api/Jugadores/BuscarJugadores/'+ search;
        axios.get(this.urlApuestasAPI + request).then(response=>{
            this.setState({
                jugadores : response.data
            });
        }).catch(error=>{
            console.log(error.message);
        });
    }

    Render_JugadoresTabla = ()=>{
        if(this.state.jugadores.length === 0)
            return("");

        return(<table className="table">
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
      </table>)
    }


    render(){
        return(<div>
            <section className="py-5 text-center container">
                <div className="row py-lg-5">
                    <div className="col-lg-6 col-md-8 mx-auto">
                        <h1 className="fw-light">HOME</h1>
                        <p className="lead text-body-secondary">APUESTAS DEL CALSICO</p>
                    </div>
                </div>
            </section>       
            <div className="input-group input-group-sm mb-3">               
                <input type="text"  className="form-control" placeholder="Buscar" onChange={(event) =>this.GET_JugadoresNombre(event.currentTarget.value)} aria-label="Sizing example input" aria-describedby="inputGroup-sizing-sm"/>
            </div>
            {this.Render_JugadoresTabla()}
        </div>)
    }
}