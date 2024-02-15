export default class Coche{
    private modelo : string;
    private marca : string;
    private conductor : string;
    private imagen : string;
    private idcoche : number;

    constructor(idcoche ?: number, modelo ?: string, marca ?: string, conductor ?: string, imagen ?: string){
        this.idcoche = idcoche ?? NaN;
        this.modelo = modelo ?? '';
        this.marca = marca ?? '';
        this.conductor = conductor ?? '';
        this.imagen = imagen ?? '';
    }
    
    GET_IdCoche() : number{
        return(this.idcoche);
    }
    GET_Modelo() : string{
        return(this.modelo);
    }    
    GET_Marca() : string{
        return(this.marca);
    }    
    GET_Conductor() : string{
        return(this.conductor);
    }    
    GET_Imagen() : string{
        return(this.imagen);
    }

    SET_Modelo(modelo : string){
        this.modelo = modelo;
    }    
    SET_Marca(marca : string){
        this.marca = marca;
    }    
    SET_Conductor(conductor : string){
        this.conductor = conductor;
    }    
    SET_Imagen(imagen : string){
        this.imagen = imagen;
    }
}