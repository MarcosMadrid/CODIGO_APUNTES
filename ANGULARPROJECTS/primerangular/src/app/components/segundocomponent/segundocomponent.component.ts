import { Component , OnInit , DoCheck} from '@angular/core';

@Component({
  selector: 'app-segundocomponent',
  templateUrl: './segundocomponent.component.html',  
  styleUrls : ['./segundocomponent.component.css'],
})
export class SegundocomponentComponent {
  public mensaje: string;
  public condicion: boolean;
  public deportes: string[];
  public numeros : number[];

  constructor(){
    this.mensaje = "Mensajito";
    this.condicion = true;
    this.deportes = ["tenis","futbol","beisbol","baloncesto"];
    this.numeros = []
    for (const item of  Array(parseInt(String(Math.random()*100 + 1)))) {
      this.numeros.push(parseInt(String(Math.random()*100)));
    }
  }

  ngOnInit(): void{
    console.log("OnInit metodo");    
  }
  ngDoCheck(): void{
    console.log("ngDoCheck metodo");  
  }

  CambiarMensaje(){
    this.mensaje = "Has cambiado el mensaje";
    this.condicion = false;
  }
}
