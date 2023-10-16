import SaludoHijo from "./SaludoHijo";

function SaludoPadre(){

    const FuncionPadre = function(){
        console.log("Función del padre")
    };
 
    return(
        <div>
            <h1>Soy el padre</h1>
            <SaludoHijo  metodoPadre={FuncionPadre}/>
        </div>
    )
}

export default SaludoPadre;