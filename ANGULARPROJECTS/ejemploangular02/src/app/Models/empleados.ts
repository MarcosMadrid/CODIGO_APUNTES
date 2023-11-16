export default class Empleado{
    
    private idEmpleado: number;
    private idHospital: number;
    private idSala: number;
    private apellido: string;
    private funcion: string;
    private turno: string;
    private salario: number;

    constructor(idEmpleado?: number,idHospital ?: number, idSala?: number, apellido?: string, funcion?: string, turno?: string, salario?: number,){
        this.idEmpleado = idEmpleado ?? NaN;
        this.idHospital = idHospital ?? NaN;
        this.idSala = idSala ?? NaN;
        this.apellido = apellido ?? '';
        this.funcion = funcion ?? '';
        this.turno = turno ?? '';
        this.salario = salario ?? NaN;
    }

    Get_IdEmpleado() : number{
        return (this.idEmpleado);
    }
    Get_IdHospital() : number{
        return (this.idHospital);
    }
    Get_IdSala() : number{
        return (this.idSala);
    }
    Get_Apellido() : string{
        return (this.apellido);
    }
    Get_Funcion() : string{
        return (this.funcion);
    }
    Get_Turno() : string{
        return (this.turno);
    }
    Get_Salario() : number{
        return (this.salario);
    }
}