import {Component} from 'react';
import axios from 'axios';
import Globals from '../Globals';

export default class HospitalesDetalles extends Component{
    urlAzureAPI = Globals.urlAzureAPI;

    state={
        idHospitales : null,
        hospitales : [],
        data : []
    }

    GET_Hospital= async (id_hospital)=>{
        var request = 'api/hospitales/' + id_hospital;
        await axios.get(this.urlAzureAPI + request).then(response=>{
            this.setState({
                data : response.data
            });
        }).catch(error=>{
            console.log(error.message);
        });
    }

    Render_DetallesHospitales=()=>{
        console.log(this.state.hospitales)
        if(this.state.hospitales.length === 0)
            return;
        return(
        <table className="table">
            <thead>
                <tr>
                {
                    Object.keys(this.state.hospitales[0]).map((key, index_key)=>{
                        return(<th key={index_key}>{key.toUpperCase()}</th>);
                    })
                }
                </tr>
            </thead>
            <tbody>               
                {
                    this.state.hospitales.map((hospital, index_hospital)=>{
                        var cells = [];
                        Object.values(hospital).map((value,index_value)=>{
                            cells.push(<td key={index_value}>{value}</td>);
                        });
                        return(<tr key={index_hospital}>{cells}</tr>);
                    }) 
                }                
            </tbody>
        </table>);
    }

    componentDidMount=()=>{        
        this.setState({
            idHospitales : this.props.id_hospitales
        });
        this.props.id_hospitales.every((id_hospital , value)=>{   
            this.GET_Hospital(id_hospital);
            this.state.hospitales.push(this.state.data);
        });        
        this.setState({
            hospitales : this.state.hospitales
        });                  
    }

    componentDidUpdate=(before)=>{
        if(this.areEqual(this.props.id_hospitales , before.id_hospitales) === false){
            this.state.hospitales = [];
            this.props.id_hospitales.every((id_hospital, index)=>{
                this.GET_Hospital(id_hospital);
                this.state.hospitales.push(this.state.data);
            });
            this.setState({
                hospitales: this.state.hospitales
            });
        }                
    }

    areEqual(array1, array2) {
        if (array1.length === array2.length) {
          return array1.every((element, index) => {
            if (element === array2[index]) {
              return true;
            }      
            return false;
          });
        }
      
        return false;
      }

    render(){
        return(<div id="HospitalesDetalles">
            {this.Render_DetallesHospitales()}
        </div>);
    }
}