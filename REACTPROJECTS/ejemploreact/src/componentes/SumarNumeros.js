import { useRef } from "react";


function SumarNumeros(props){
    var input_numero1 = useRef();
    var input_numero2 = useRef();   

    var solucion = useRef();
    var estilo;


    const Sumar = function(){
        var numero1 = parseInt(input_numero1.current.value);
        var numero2 = parseInt(input_numero2.current.value);
        var final = numero1 + numero2

        solucion.current.innerText = "Resultado es: " +  final;

        estilo = {
            color:"green"
        };
    }

    return(
        <div>
            <input type="number" ref={input_numero1}></input>
            <input type="number" ref={input_numero2}></input>
            <button onClick={() => Sumar()}>Sumar</button>
            <h2 ref={solucion} style={estilo}>Resultado</h2>
        </div>
    )
}

export default SumarNumeros;