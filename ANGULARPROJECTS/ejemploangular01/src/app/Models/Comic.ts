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
        return this.descripcion;
    }
    Set_Imagen(imagen : string){
        this.imagen = imagen;
        return this.descripcion;
    }
    Set_Descripcion(descripcion : string){
        this.descripcion = descripcion;
        return this.descripcion;
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