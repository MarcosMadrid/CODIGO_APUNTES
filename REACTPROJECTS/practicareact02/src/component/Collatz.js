import React,{Component} from 'react';

export default class Collatz extends Component{
    numero_input = React.createRef();

    state={
        serie : []
    }


    TeoremaCollatz = ()=>{
        this.state.serie.splice(0,this.state.serie.length);
        let numero = parseFloat(this.numero_input.current.value);

        this.state.serie.push(numero);

        while(numero !== 1){
            if(numero % 2 === 0){
                numero = numero/2;
            }else{
                numero  = numero* 3 + 1 ;    
            }
            this.state.serie.push(numero);
        }
        this.setState({serie : this.state.serie});
    }



    render(){
        return(<div>
            <input ref={this.numero_input} placeholder='inserte numero'/>
            <button onClick={()=> this.TeoremaCollatz()}>Insertar numero</button>
            <hr/>
            {
                this.state.serie.map((numero, index)=>{
                    return(numero+", ")
                })
            }
        </div>)
    }

}