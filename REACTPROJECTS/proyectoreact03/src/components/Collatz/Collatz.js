import {Component} from 'react';

export default class Collatz extends Component{
    numero = this.props.numero

    serie = []

    TeoremaCollatz=()=>{
        this.serie = [];
        while(this.numero > 1){
            this.serie.push(this.numero);
            if(this.numero%2 === 0){
                this.numero = this.numero / 2
            }else{
                this.numero * 3 + 1 
            }
        }
    }

    render(){
        return(<ul>
                {
                  this.serie.map((value, index)=>{
                    return(<li>{value}</li>)
                  })
                }
        </ul>)
    }
} 