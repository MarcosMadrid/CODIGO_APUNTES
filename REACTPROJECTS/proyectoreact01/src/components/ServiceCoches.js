import {React, Component, createRef} from 'react';
import Global from '../Global';
import axios from 'axios';
export default class ServiceCoches extends Component{
    urlApiCoches = Global.urlApiCoches;
    input_cocheId = createRef();

    state={
        coches : []
    }
   
    GetCoches = ()=>{
        let urlRequest = '/webresources/coches'
        axios.get(this.urlApiCoches + urlRequest).then(response=>{
            this.setState({
                coches: response.data
            });
        });
    }

    ListCoches = ()=>{
        let tbody = [];
        this.state.coches.map((coche, index) => {   
            let cells = [];
            Object.values(coche).forEach((value, valueIndex) => {
                let cell = <td key={valueIndex}>{value}</td>;
                if(valueIndex === Object.values(coche).length - 1)
                    cell = <td key={valueIndex}><img src={value} style={{width:'50px',height:'50px'}} alt={index}/></td>;                    
                cells.push(cell);
            });  
            let row = (<tr key={index}><td>{index}</td>{cells}</tr>);
            tbody.push(row);
        });
        return(tbody)
    }

    GetCochesMarca = ()=>{  
        let marca = this.input_cocheId.current.value.toUpperCase();
        if(marca === ""){
            this.GetCoches();
        }
        let coches_marca = this.state.coches.filter(coche => coche.marca.toUpperCase().includes(marca))
        console.log(coches_marca);
        this.setState({
            coches: coches_marca
        });
    }

    componentDidMount = ()=>{
        this.GetCoches();
        this.input_cocheId.current.addEventListener("keydown", ()=>{
            this.GetCochesMarca();   
        });
    }

    render(){
        return(<div>
            <h1>ServiceCoches</h1>
            <input placeholder='Marca coche' ref={this.input_cocheId}></input>
            <table> 
                <tbody>
                    {this.ListCoches()}
                </tbody>
            </table>
        </div>);
    }
}