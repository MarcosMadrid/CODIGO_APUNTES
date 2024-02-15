export default class Serie{
    public idSerie : number
    public nombre : string
    public imagen : string
    public puntuacion : number
    public anyo : number

    constructor(idSerie ?: number , nombre ?: string , imagen ?: string , puntuacion ?: number ,  anyo ?: number){
        this.idSerie = idSerie ?? NaN;
        this.nombre = nombre ?? '';
        this.imagen = imagen ?? '';
        this.puntuacion = puntuacion ?? NaN;
        this.anyo = anyo ?? NaN;
    }
}