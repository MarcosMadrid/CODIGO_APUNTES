import { Component, ViewChild,  ElementRef } from '@angular/core';

@Component({
  selector: 'app-tablamultiplicarcomponent',
  templateUrl: './tablamultiplicarcomponent.component.html'
})
export class TablamultiplicarcomponentComponent {
  @ViewChild("cajaNumero") cajaNumeroRef !: ElementRef;
  public multiplicaciones !: number[]
  isNaN : Function = Number.isNaN;
  TablaMultiplicar(){
    this.multiplicaciones = [];
    for(let i = 0 ; i<=10 ; i++){
      this.multiplicaciones.push(parseInt(this.cajaNumeroRef.nativeElement.value) * i);      
    }
  }
}
