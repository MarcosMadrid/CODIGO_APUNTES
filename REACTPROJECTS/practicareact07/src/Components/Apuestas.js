import { Component } from "react";
import axios from 'axios';
import Globals from "../Globals";
import { NavLink } from "react-router-dom";

export default class Apuestas extends Component{
    urlApuestasAPI = Globals.urlApuestasAPI;

    state = {
        apuestas : []
    }

    GET_Apuestas = ()=>{
        var request = '/api/apuestas';
        axios.get(this.urlApuestasAPI + request).then(response=>{
            this.setState({
                apuestas : response.data
            });
        }).catch(error=>{
                console.log(error.message);
        });
    }

    componentDidMount = ()=>{
        this.GET_Apuestas();
    }

    render(){
        if(this.state.apuestas.length === 0)
            return("");

        return(<div>
            <NavLink to={'/apuesta/crear/'} className={'btn btn-danger'}> Realizar apuesta </NavLink>
            <div className="col-felx center">
                <table className="table">
                    <thead>
                        <tr>
                            <th scope="col"> INDEX </th>
                        {
                            Object.keys(this.state.apuestas[0]).map((apuesta_key , index)=>{
                                return(<th scope="col" key={index}> {apuesta_key.toUpperCase()} </th>);
                            })
                        }
                        </tr>
                    </thead>
                    <tbody className="table-group-divider">
                        {
                            this.state.apuestas.map((apuesta, index_apuesta)=>{
                                var cells = [];
                                cells.push(<th scope="row" key={0} >{index_apuesta}</th>);
                                Object.values(apuesta).map((value , index)=>{
                                    cells.push(<td key={index+1} >{value}</td>);
                                });
                                return(<tr key={index_apuesta} >{cells}</tr>);
                            })
                        }                
                    </tbody>
                </table>
            </div>

        </div>);
    }
}