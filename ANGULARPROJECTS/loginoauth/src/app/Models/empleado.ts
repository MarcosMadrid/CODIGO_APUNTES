export default class Empleado{
    
    private idEmpleado: number;
    private apellido: string;
    private director: string;
    private oficio: string;
    private salario: number;

    constructor(idEmpleado?: number,idHospital ?: number, idSala?: number, apellido?: string, director?: string, oficio?: string, salario?: number,){
        this.idEmpleado = idEmpleado ?? NaN;
        this.apellido = apellido ?? '';
        this.director = director ?? '';
        this.oficio = oficio ?? '';
        this.salario = salario ?? NaN;
    }

    Get_IdEmpleado() : number{
        return (this.idEmpleado);
    }
    Get_Apellido() : string{
        return (this.apellido);
    }
    Get_Director() : string{
        return (this.director);
    }
    Get_Oficio() : string{
        return (this.oficio);
    }
    Get_Salario() : number{
        return (this.salario);
    }
}