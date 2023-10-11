function Saludo(prop) {
    var dato = "Fiesta en mi casa";
    var nombre = prop.nombre;
    var edad = prop.edad;

    // tambien se puede const { nombre, edad } = props;
    return(
        <div>
            <h1>Objetivo dato: {dato}</h1>
            <h2>Nombre: {nombre}</h2>
            <h2>Edad: {edad}</h2>            
        </div>
    )
  }

export default Saludo;