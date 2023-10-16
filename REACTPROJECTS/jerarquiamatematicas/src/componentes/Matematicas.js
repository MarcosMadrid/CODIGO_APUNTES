function Matematicas(props){

    var resultado = props.resultado;
    var input = props.input;
    var multiplicar3 = props.multiplicar3;

    const multiplicar2 = function(resultado){
        var numero = parseInt(input.current.value);
        var final = numero * 2;
        resultado.current.innerText = "Resultado: " + final;
    }

    return(
        <div>
            <button onClick={() =>  multiplicar2(resultado)}>Por 2</button>
            <button onClick={() => multiplicar3(resultado)}>Por 3</button>
        </div>
    )
}

export default Matematicas;