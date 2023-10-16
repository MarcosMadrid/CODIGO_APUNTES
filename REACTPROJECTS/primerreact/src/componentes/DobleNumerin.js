import { useRef } from "react";

function DobleNumerin(){
    var inputRef = useRef();
    var resultado = useRef();

var estilo ={
    color:"blue",
}


const numeroDoble = function(){    
    var numeroinput = parseInt(inputRef.current.value);
    var doble = numeroinput*2;
    resultado.current.innerText= "Resultado es: " + doble;
}
    return(
        <div>
            <h1>Ejemplo parámetros</h1>
            <hr/>
            <input type="number" ref={inputRef} />
            <button onClick={() => numeroDoble() }> Insertar</button>
             <h2 ref={resultado} style={estilo}>Resultado</h2>
            <hr/>
            
            
        </div>
    )
}

export default DobleNumerin;