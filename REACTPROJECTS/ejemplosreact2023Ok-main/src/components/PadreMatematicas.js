import Matematicas from "./Matematicas";

function PadreMatematicas() {
    const mostrarTriple = (num) => {
        var triple = parseInt(num) * 3;
        alert("Triple " + triple);
    }

    return (<div>
        <h1 style={{color: "blue"}}>Padre matemáticas</h1>
        <Matematicas numero="14" mostrarTriple={mostrarTriple}/>
        <Matematicas numero="55" mostrarTriple={mostrarTriple}/>
    </div>)
}

export default PadreMatematicas;