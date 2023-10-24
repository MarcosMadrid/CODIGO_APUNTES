import axios from "axios";
import { Component } from "react"
import Globals from "../../Globals";
import { NavLink } from "react-router-dom";

export default class Hospitales extends Component{
    urlHospitalesAPI = Globals.urlHospitalesAPI;
    state={
        hospitales : []
    }

    GetHospitales=()=>{
        var request='/webresources/hospitales';
        axios.get(this.urlHospitalesAPI + request).then(response=>{
            this.setState({
                hospitales: response.data
            })
        });
        
    }

    componentDidMount = ()=>{
        this.GetHospitales();
    }

    render(){
        return(<div>
            <table className="table">
                <thead>
                    <tr>
                    {
                        this.state.hospitales.length !== 0 &&                            
                            Object.keys(this.state.hospitales[0]).map((key,index_key)=>{
                                return(<td key={index_key}>{key.toUpperCase()}</td>);
                            })
                                            
                    }                         
                    </tr>
                </thead>
                <tbody>                    
                    {
                        this.state.hospitales.map((hospital,index)=>{
                            var cells = [];
                            Object.values(hospital).map((value,index_value)=>{
                                cells.push(<td key={index_value}>{value}</td>);
                            });
                           
                            return(<tr key={index}>{cells}  <NavLink to={"/hospital/"+hospital.idhospital}><button className="btn-primary">Detalles</button></NavLink>  </tr>)
                        })                        
                    }                                      
                </tbody>
                </table>
        </div>);
    }
}