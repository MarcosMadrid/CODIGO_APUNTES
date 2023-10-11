function Metodos(variable) {
    const mostrarMensaje = () =>{
        console.log("Boton pulsado")
    }

    return(
        <div>            
            {mostrarMensaje()}
            <h1> Ejemplo metodo  </h1>
            <button onClick={() => mostrarMensaje()}>Boton</button>            
        </div>
        )
  }

export default Metodos;