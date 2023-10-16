import { useRef } from "react";
import Matematicas from "./Matematicas";

function MatematicasPadre(){

    var input = useRef();
    var resultado = useRef();   

    const multiplicar3 = function(resultado){
        var numero = parseInt(input.current.value);
        var final = numero * 3;
        resultado.current.innerText = "Resultado: " + final;
    }

    return(
        <div>
            <input type="number" ref={input}/>            
            <Matematicas resultado={resultado} input={input} multiplicar3={multiplicar3} />
            <h1 ref={resultado}>Resultado:</h1>
        </div>
    )
}

export default MatematicasPadre;