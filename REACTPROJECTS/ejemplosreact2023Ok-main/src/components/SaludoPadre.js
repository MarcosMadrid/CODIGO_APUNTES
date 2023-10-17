import SaludoHijo from "./SaludoHijo";
function SaludoPadre() {
    //NECESITAMOS UN METODO PARA PODER EJECUTAR LA ACCION
    //CUANDO EL HIJO LO NECESITE
    const metodoPadre = (nombre) => {
        console.log("Yo soy tu Padre, " + nombre);
    }
    return (<div>
        <h1 style={{color:"red"}}>Saludo PARENT</h1>
        {/* EL METODO LO LLAMAREMOS DESDE EL HIJO 
        POR LO QUE DEBEMOS ENVIAR, MEDIANTE PROPS
        EL METODO AL HIJO EN SU DIBUJO
        */}
        <SaludoHijo idhijo="1" metodoPadre={metodoPadre}/>
        <SaludoHijo idhijo="2" metodoPadre={metodoPadre}/>
        <SaludoHijo idhijo="3" metodoPadre={metodoPadre}/>
    </div>)
}

export default SaludoPadre;