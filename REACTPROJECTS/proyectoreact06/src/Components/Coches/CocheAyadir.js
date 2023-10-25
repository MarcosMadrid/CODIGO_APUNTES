import {Component, createRef} from 'react'
import Globals from '../../Globals';
import axios from 'axios';
import Swal from 'sweetalert2';

export default class CocheAyadir extends Component{
    urlCochesAPI = Globals.urlCochesAPI;
    input_id = createRef();
    input_marca =  createRef();
    input_modelo =  createRef();
    input_conductor =  createRef();
    input_imagen =  createRef();

    Submit_Coche=(e)=>{
        e.preventDefault();
        var coche={
            idCoche : this.input_id.current.value,
            marca : this.input_marca.current.value,
            modelo : this.input_modelo.current.value,
            conductor : this.input_conductor.current.value,
            imagen : this.input_imagen.current.value,
        }

        this.Insert_Coche(coche)
    }
    
    Insert_Coche = (coche)=>{
        var request = 'api/coches/insertcoche/';
        axios.post(this.urlCochesAPI + request, coche).
        then(response=>{
            Swal.fire({
                icon: 'succes',
                title: 'Coche añadido',
                text: 'El coche '+ coche.idCoche +', ha sido añadido.' ,
            });
        }).
        catch(error=>{
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Something went wrong!',
                footer: error.message,
            });
        });
    }

    render(){
        return(<div>
                <form className='col-md-6 d-block mx-auto'>
                    <div className="mb-3">
                        <label htmlFor="input_id" className="form-label">ID COCHE</label>
                        <input type="text" className="form-control" ref={this.input_id} id="input_id" aria-describedby="ID_COCHE"/>
                    </div>
                    <div className="mb-3">
                        <label htmlFor="input_marca" className="form-label">MARCA</label>
                        <input type="text" className="form-control" ref={this.input_marca} id="input_marca"/>
                    </div>
                    <div className="mb-3">
                        <label htmlFor="input_modelo" className="form-label">MODELO</label>
                        <input type="text" className="form-control" ref={this.input_modelo} id="input_modelo"/>
                    </div>
                    <div className="mb-3">
                        <label htmlFor="input_conductor" className="form-label">CONDUCTOR</label>
                        <input type="text" className="form-control"ref={this.input_conductor} id="input_conductor"/>
                    </div>
                    <div className="mb-3">
                        <label htmlFor="exampleInputPassword1" className="form-label">IMAGEN</label>
                        <input type="file" className="form-control" ref={this.input_imagen} id="input_imagen"/> 
                    </div>
                    <button type='button' className="btn btn-primary" onClick={this.Submit_Coche}>Añadir</button>
                </form>
        </div>);        
    }
}