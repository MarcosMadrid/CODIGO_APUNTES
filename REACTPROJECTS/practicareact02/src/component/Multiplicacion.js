import {Component} from 'react';
import React from 'react';

export default class Mulltiplicacion extends Component{
    select_numero = React.createRef();
    tabla = [0,1,2,3,4,5,6,7,8,9,10];
    state={
        numero : null,
        serie : []
    }

    Multiplicar = ()=>{
        let numero = parseFloat(this.select_numero.current.value);
        this.tabla.map((fila, index)=>{
            this.tabla[index]= numero * index;
        });
        this.setState({
            numero: numero,
            serie: this.tabla
        });
    }


    render(){
        return(<div>
            <h1>Multiplicación</h1>
            <select type='number' ref={this.select_numero} placeholder='Inserte numero'>
            {
                this.tabla.map((numero, index)=>{
                    let numero_random = parseInt((Math.random()*1000) +1);
                    return(<option in value={numero_random}>{numero_random}</option>);
                })
            }
            </select>

            <button onClick={()=>this.Multiplicar()}>Ejecutar</button>
            <table>
            {
                this.state.serie.map((fila,index)=>{
                    return(<tbody>
                        <td>
                            <tr>{this.state.numero} * {index}</tr>
                        </td>
                        <td>
                            <tr>{fila}</tr>
                        </td>
                    </tbody>)
                })   
            }
            </table>
        </div>)
    }
} 