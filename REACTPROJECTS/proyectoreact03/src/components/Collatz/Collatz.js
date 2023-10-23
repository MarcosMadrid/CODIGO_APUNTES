import {Component} from 'react';


export default class Collatz extends Component{
    numero = parseInt(this.props.numero);

    state ={
        serie : []
    }
   
    TeoremaCollatz=()=>{
        this.state.serie = [];
        while(this.numero > 1){
            if(this.numero%2 === 0){
                this.numero = this.numero / 2
            }else{
                this.numero = this.numero * 3 + 1 
            }
            this.state.serie.push(this.numero);
        }
        this.setState({
            serie : this.state.serie
        })
        console.log(this.state.serie)
    }
    
    componentDidMount=()=>{
        this.TeoremaCollatz();
    }

    componentDidUpdate = (before)=>{
        if(before.numero !== this.props.numero){
            this.TeoremaCollatz();
        }
    }

    render(){
        return(<ul>
                {
                  this.state.serie.map((value, index)=>{
                    return(<li>{value}</li>)
                  })
                }
        </ul>)
    }
} 