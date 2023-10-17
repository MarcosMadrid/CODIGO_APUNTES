import { useState } from "react";

function Car(props) {
    //TENDREMOS UNA VARIABLE PARA AVERIGUAR EL ESTADO DEL COCHE
    const [ estado, setEstado] = useState(false);
    //UNA VARIABLE PARA VISUALIZAR LA VELOCIDAD ACTUAL DEL COCHE
    const [ velocidad, setVelocidad ] = useState(0);
    //CREAMOS UN OBJETO COCHE CON TODAS LAS CARACTERISTICAS NECESARIAS
    //EN FORMA DE PROPIEDADES
    var coche = {
        marca: props.marca, 
        modelo: props.modelo,
        aceleracion: parseInt(props.aceleracion), 
        velocidadMaxima: parseInt(props.velocidadmaxima)
    }
    //VAMOS A TENER UNA FUNCIONALIDAD QUE NOS PERMITIRA 
    //ARRANCAR/DETENER EL COCHE MEDIANTE LA VARIABLE ESTADO
    //TENDREMOS UN METODO QUE NOS DEVOLVERA UN DIBUJO HTML
    //DEPENDIENDO DE DICHO ESTADO.
    const comprobarEstado = () => {
        if (estado === true){
            return (<h1 style={{color:"green"}}>Arrancado</h1>);
        }else{
            return (<h1 style={{color:"red"}}>Detenido</h1>);
        }
    }

    //CREAMOS UN METODO PARA CAMBIAR LA ACELERACION DEL COCHE
    const acelerarCoche = () => {
        if (estado === false){
            alert("El coche está detenido");
            setVelocidad(0);
        }else{
            if (velocidad >= coche.velocidadMaxima){
                //PONEMOS LA VELOCIDAD MAXIMA DEL COCHE
                setVelocidad(coche.velocidadMaxima);
            }else{
                //ACELERAMOS CON LA PROPIEDAD aceleracion DEL COCHE
                setVelocidad(velocidad + coche.aceleracion);
            }
        }
    }

    return (<div>
        <h1 style={{color:"fuchsia"}}>
            Component Car {coche.marca}, {coche.modelo}
        </h1>
        <h1 style={{color: "blue"}}>
            Velocidad actual: {velocidad} Km/h
        </h1>
        <div>
            {comprobarEstado()}
        </div>
        <button onClick={ () => {
            //CAMBIAMOS EL VALOR DE LA VARIABLE estado
            setEstado(!estado);
            console.log("Cambiando estado: " + estado);
        }}>Arrancar/Detener</button>
        <button onClick={ () => acelerarCoche()}>Acelerar coche</button>
    </div>)
}

export default Car;