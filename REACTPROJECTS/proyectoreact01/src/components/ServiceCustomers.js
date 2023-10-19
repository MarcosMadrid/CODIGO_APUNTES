import {React, Component, createRef} from 'react';
import axios from 'axios';
import Global from '../Global';

export default  class ServiceCustomers extends Component{
    urlApiCustomers=Global.urlApiCustomers;
    input_clienteId = createRef();

    state={
        customers : []
    }
   
    GetCustomers = ()=>{
        let urlRequest = 'customers.json'
        axios.get(this.urlApiCustomers + urlRequest).then(response=>{
            this.setState({
                customers: response.data.results
            })
            console.log(this.state.customers);
        });
    }

    ListCustomers = ()=>{
        let tbody = [];
        this.state.customers.map((customer, index) => {   
            let cells = [];
            Object.values(customer).forEach((value, valueIndex) => {
                let cell = <td key={valueIndex}>{value}</td>;
                cells.push(cell);
            });  
            let row = (<tr key={index}><td>{index}</td>{cells}</tr>);
            tbody.push(row);
        });
        return(tbody)
    }

    GetCustomer = ()=>{    
        if(this.input_clienteId.current.value === ""){
            this.GetCustomers();
            return;
        }   
        let customer_Id = this.input_clienteId.current.value;
        let urlRequest = 'customers/' + customer_Id + '.json';
        axios.get(this.urlApiCustomers + urlRequest).then(response=>{
            let customers = [response.data.customer]
            this.setState({
                customers: customers
            });
        });
    }

    componentDidMount = ()=>{
        this.GetCustomers(); //Se ejecuta unicamente cuando se dibuja el componente
        this.input_clienteId.current.addEventListener("change", ()=>{
            this.GetCustomer();   
        })
    }

    

    render(){
        return(<div>
            <h1>ServiceCustomers</h1>  
            <input placeholder='ID cliente' ref={this.input_clienteId} ></input>
            <table> 
                
                <tbody>
                    {this.ListCustomers()}                                  
                </tbody>
            </table>
        </div>)
    }
}