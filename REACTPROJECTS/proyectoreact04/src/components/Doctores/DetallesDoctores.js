import {Component} from 'react';
import Globals from '../../Globals';
import axios from 'axios';

export default class DetallesDoctores extends Component{
    urlDoctoresAPI = Globals.urlDoctoresAPI;

    state ={
        doctor_data : []
    }
    
    GetDoctor=()=>{
        let request = '/api/Doctores/' + this.props.id_doctor; 
        axios.get(this.urlDoctoresAPI + request).then(response=>{
            this.setState({
                doctor_data : response.data
            });
        });
    }

    componentDidMount=()=>{
        this.GetDoctor();
    }

    componentDidUpdate = (before)=>{
       if(before.id_doctor !== this.props.id_doctor)
            this.GetDoctor();
    }

    render(){
        return(<div>
            <table className="table">
                <thead>
                    <tr>
                    {
                        Object.keys(this.state.doctor_data).map((key,index)=>{
                            return(<th key={key} scope='col'>{key.toUpperCase()}</th>);
                        })
                    }
                    </tr>
                </thead>
                <tbody>
                    <tr>
                    {
                        Object.values(this.state.doctor_data).map((value,index)=>{
                            return(<td key={value}>{value}</td>);
                        })                        
                    }
                    </tr>
                </tbody>
            </table>
            </div>)
    }

}