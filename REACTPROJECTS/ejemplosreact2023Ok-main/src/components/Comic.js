import {Component} from 'react'

class Comic extends Component{
    comic = this.props.comic;
    index = parseInt(this.props.index);

    titulo = this.comic.titulo;
    descripcion = this.comic.descripcion;
    imagen = this.comic.imagen;

    render(){
        return(
            <div>
                <hr></hr>
                <h2>{this.titulo}</h2>
                <img src={this.imagen} alt={this.descripcion} style={{width:"50px",height:"100px"}}></img>
                <p></p>
                {this.descripcion}
                <p></p>
                <button onClick={()=>{
                    this.props.SeleccionarFavorito(this.comic)
                }}>
                    Añadir favorito</button>
                <button onClick={()=>{
                    this.props.EliminarComic(this.index)
                }}>
                    Eliminar Comic</button>
                <hr></hr>
            </div>
        )
    }

}

export default Comic;