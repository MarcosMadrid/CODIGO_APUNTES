import { useState } from "react";

function Coche(props){
    
    // ESTADO DEL COCHE VARIABLE
    const [estado, setEstado] = useState(false);
    // VELOCIDAD DEL COCHE VARIABLE
    const [velocidad, setVelocidad] = useState(0);
    
    // OBJETO COCHE CON TODOS LOS ATRIBUTOS DE ESTA
    var coche = {
        marca: props.marca,
        modelo: props.modelo,
        aceleracion: parseInt(props.aceleracion),        
        velocidad_max: parseInt(props.velocidadmaxima)
    };

    const comprobarEstado = function(){
            if(estado === true){
                return (<h1 style={{color:"green"}}>Arrancado</h1>);
            }else{
                return (<h1 style={{color:"red"}}>Detenido</h1>);
            }
    };

    const cambiarVelocidad = function(){
        if(estado === false){
            alert("El coche esta detenido!!!");
            setVelocidad(0);
        }else{
            if(velocidad >= coche.velocidad_max){
                alert("Limite de velocidad");
                setVelocidad(coche.velocidad_max);
            }else{
                setVelocidad(coche.aceleracion + velocidad);
            }
        }
    };


    return(
        <div>
            <h1>Coche</h1>
            <button onClick={() => {
                setEstado(!estado)
                console.log("Estado cambiado =>" + estado)
                }}>
            Cambiar estado</button>
            <ul>
                <li>
                    marca: {coche.marca}
                </li>                
                <li>
                    modelo: {coche.modelo}
                </li>                
                <li>
                    aceleracion: {coche.aceleracion}
                </li>                
                <li>
                    velocidad: {velocidad}
                    <button onClick={() => cambiarVelocidad()}>Aumentar</button>
                </li>
            </ul>
            <div>
            {comprobarEstado()}
            </div>
        </div>
    )
}

export default Coche;