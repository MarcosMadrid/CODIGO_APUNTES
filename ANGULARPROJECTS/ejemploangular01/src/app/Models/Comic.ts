export class Comic{
    private titulo : string;
    private imagen : string;
    private descripcion : string;

    constructor(titulo ?: string ,imagen ?: string, descripcion ?: string){
        this.titulo = titulo ?? '';
        this.imagen = imagen ?? '';
        this.descripcion = descripcion ?? '';    
    }

    Set_Titulo( titulo : string){
        this.titulo = titulo;
    }
    Set_Imagen(imagen : string){
        this.imagen = imagen;
    }
    Set_Descripcion(descripcion : string){
        this.descripcion = descripcion;
    }
    
    Get_Titulo(){
        return (this.titulo);
    }
    Get_Imagen(){
        return (this.imagen);
    }
    Get_Descripcion(){
        return (this.descripcion);
    }
}