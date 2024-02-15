export default class Personaje{
    public idPersonaje : number
    public idSerie : number
    public nombre : string
    public imagen : string
    

    constructor(idPersonaje ?: number , idSerie ?: number , nombre ?: string , imagen ?: string , puntuacion ?: number ,  anyo ?: Date){
        this.idSerie = idSerie ?? NaN;
        this.nombre = nombre ?? '';
        this.imagen = imagen ?? '';
        this.idPersonaje = idPersonaje ?? NaN;
    }
}