export class Coche{
    private marca : string;
    private modelo : string;
    private velocidad : number;
    private aceleracion : number;
    private estado : boolean;

    constructor( marca ?: string, modelo ?: string, velocidad ?: number, aceleracion ?: number, estado ?: boolean, ){
        this.marca = marca ?? '';
        this.modelo = modelo ?? '';
        this.velocidad = velocidad ?? Number.NaN;
        this.aceleracion = aceleracion ?? Number.NaN;
        this.estado = estado ?? false;
    }

    Set_Marca(marca : string){
        this.marca = marca;
    }
    Set_Modelo(modelo : string){
        this.modelo = modelo;
    }
    Set_Velocidad(velocidad : number){
        this.velocidad = velocidad;
    }
    Set_Aceleracion(aceleracion : number){
        this.aceleracion = aceleracion;
    }
    Set_Estado(estado : boolean){
        this.estado = estado;
    }

    Get_Marca(){
        return this.marca;
    }
    Get_Modelo(){
        return this.modelo;
    }
    Get_Velocidad(){
        return this.velocidad;
    }
    Get_Aceleracion(){
        return this.aceleracion;
    }
    Get_Estado(){
        return this.estado;
    }
}