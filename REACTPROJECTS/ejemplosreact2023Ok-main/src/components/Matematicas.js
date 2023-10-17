function Matematicas(props) {
    var numero = props.numero;
    var mostrarTriple = props.mostrarTriple;

    const mostrarDoble = () => {
        var doble = parseInt(numero) * 2;
        console.log("Doble: " + doble);
    }

    return (<div>
        <h1 style={{color:"red"}}>Matematicas {numero}</h1>
        <button onClick={ () => mostrarDoble() }>Doble {numero}</button>
        <button onClick={ () => mostrarTriple(numero) }>Triple {numero}</button>
    </div>)
}

export default Matematicas;