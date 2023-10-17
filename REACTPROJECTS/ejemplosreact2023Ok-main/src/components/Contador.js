//PARA PODER UTILIZAR useState
//NECESITAMOS IMPORTARLO DE LA LIBRERIA react
import { useState } from "react";

function Contador() {
    //DECLARAMOS UNA VARIABLE STATE Y EN LA CREACION
    //DEBEMOS INDICAR SU VALOR RESPECTO A SU TIPO DE DATO
    const [numero, setNumero] = useState(0);
    const sumarNumero = () => {
        //PARA MODIFICAR EL VALOR DE UNA VARIABLE STATE 
        //DEBEMOS HACERLO MEDIANTE setVariable, QUE SE UTILIZA 
        //COMO METODO
        setNumero(numero + 1);
    }

    
    return (<div>
        <h1>Ejemplo useState</h1>
        <h2 style={{color:"blue"}}>Contador: {numero}</h2>
        <hr/>
        <button onClick={ () => sumarNumero() }>Sumar contador</button>
        <button onClick={ () => {
            setNumero(numero - 1);
        }  }>
            Restar contador
        </button>


    </div>)
}

export default Contador;