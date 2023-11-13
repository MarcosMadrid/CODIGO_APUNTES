export class Producto{
    private nombre:string;
    private imagen:string;
    private precio:number;

    constructor(nombre : string , imagen: string , precio : number){
        this.nombre = nombre;
        this.imagen = imagen;
        this.precio = precio;
    }
    

    Set_Nombre(nombre : string){
        this.nombre = nombre
    }
    Set_Precio(precio : number){
        this.precio = precio
    }
    Set_Imagen(imagen : string){
        this.imagen = imagen
    }
    
    Get_Nombre(){
        return(this.nombre);
    }
    Get_Precio(){
        return(this.precio);
    }
    Get_Imagen(){
        return(this.imagen);
    }
}