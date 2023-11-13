import { Component ,OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router} from '@angular/router';


@Component({
  selector: 'app-numerodoble',
  templateUrl: './numerodoble.component.html'
})
export class NumerodobleComponent implements OnInit{
  numero!: number;
  constructor(private activeRoute:ActivatedRoute, private router : Router){

  }
  ngOnInit(): void {
    this.activeRoute.params.subscribe((parametros: Params)=>{
      if(parametros['numero'] != null){
        this.numero = parseInt(parametros['numero']);
      }
    });
  }

  Redirect_GenrarNumero() {
    this.router.navigate(["doble/" , parseInt(String(Math.random()*100))]);
    
  }

}
