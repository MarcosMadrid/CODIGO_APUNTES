import batman from '../../assets/images/batman.png';
import './SumarNumeros.css';

function SumarNumeros() {
    const sumar = (numero1, numero2) => {
        var num1 = parseInt(numero1);
        var num2 = parseInt(numero2);
        var resultado = num1 + num2;
        alert("Suma: " + resultado);
    }

    var imageSize = {
        width: "150px",
        height: "150px"
    }

    return (<div>
        <h1>Sumar Números</h1>
        <button onClick={ () => sumar(3,4)}>Sumar 3 + 4</button>
        <button onClick={ () => sumar(199, 201)}>Sumar 199 + 201</button>
        <img src={batman} style={imageSize} alt='img' />
    </div>)
}

export default SumarNumeros;