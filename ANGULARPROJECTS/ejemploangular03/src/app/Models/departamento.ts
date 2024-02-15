export default class Departamento{
    public idDepartamento : number;
    public nombre : string;
    public localidad : string;

    constructor(idDepartamento ?:  number, nombre ?: string ,localidad ?: string ){
        this.idDepartamento =  idDepartamento ?? NaN;
        this.nombre = nombre ?? '';
        this.localidad = localidad ?? '';    
    }
}