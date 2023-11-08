import { Component } from "@angular/core";

@Component({
    selector: "app-forms-binding",
    templateUrl: "formbinding.component.html"
})

export class FormsBindingComponent{
    user : any;
    mensaje : string;
    constructor(){
        this.mensaje = '';
        this.user={
            nombre : null,
            apellido : null,
            edad : null
        }
    }
    recibirDatos(){
        this.mensaje = 'Datos recibidos';
    }
    Submit_Datos(event : any){
        console.log(event)
        event.preventDefault();
    }
}
