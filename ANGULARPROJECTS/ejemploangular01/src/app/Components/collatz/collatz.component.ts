import { Component ,OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-collatz',
  templateUrl: './collatz.component.html'
})
export class CollatzComponent implements OnInit {
  numeros !: Array<number>
  numero !: number
  constructor(private acttiveRoute:ActivatedRoute ,private router: Router){

  }
  ngOnInit(): void {
    this.acttiveRoute.params.subscribe((parametro : Params)=>{
      if(parametro['numero'] != null){
        this.numero = parseInt(parametro['numero'])
        this.TeoremaCollatz(this.numero);
      }
    })
  }
  Reirect_Collatz() {
    this.router.navigate(['/collatz', parseInt(String(Math.random()*100))+1]);
  }
  TeoremaCollatz(numero:number){
    this.numeros = Array();
    while(numero != 1){
      if(numero%2 == 0){
        numero = numero/2;
      }else{
        numero = numero*3+1;
      }
      this.numeros.push(numero);
    }
  }
}
