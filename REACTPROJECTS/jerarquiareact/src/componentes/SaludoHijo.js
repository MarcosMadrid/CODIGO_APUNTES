function SaludoHijo(props){

    var herenciapadre = props.metodoPadre;

    return(
        <div>
            <h1>Hijo Element</h1>
            <button onClick={() => herenciapadre() }>Llamar padre</button>
        </div>
    )

}

export default SaludoHijo;