export class Persona{
    private IdPersona: number;
    private Nombre: string;
    private Email: string;
    private Edad: number;

    constructor(id_persona?: number, nombre?: string, email?: string, edad?: number){
        this.IdPersona = id_persona ?? NaN;
        this.Nombre = nombre ?? '';
        this.Email = email ?? '';
        this.Edad = edad ?? NaN;
    }

    Get_IdPersona() : number{
        return(this.IdPersona);
    }
    Get_Nombre() : string{
        return(this.Nombre);
    }
    Get_Email() : string{
        return(this.Email);
    }
    Get_Edad() : number{
        return(this.Edad);
    }

    Set_IdPersona(id_persona : number) : void{
        this.IdPersona= id_persona;
    }
    Set_Nombre(nombre : string) : void{
        this.Nombre = nombre;
    }
    Set_Email(email : string) : void{
        this.Email = email;
    }
    Set_Edad(edad : number) : void{
        this.Edad = edad;
    }
}