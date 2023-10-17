function SaludoHijo(props) {
    //CAPTURAMOS EN UNA VARIABLE DE METODO EL PROPS
    //QUE VIENE DEL PARENT (metodoPadre)
    var ejecutarPadre = props.metodoPadre;
    var idhijo = props.idhijo;
    
    return (<div>
        <h1 style={{color:"blue"}}>Saludo HIJO</h1>
        <button onClick={ () => ejecutarPadre('Luke ' + idhijo) }>
            Llamar al Parent
        </button>
    </div>)
}

export default SaludoHijo;