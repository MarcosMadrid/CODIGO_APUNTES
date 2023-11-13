import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Producto } from 'src/app/Models/Producto';

@Component({
  selector: 'app-detalleproducto',
  templateUrl: './detalleproducto.component.html'
})
export class DetalleproductoComponent implements OnInit{
  producto !: Producto;
  constructor(private activeRoute:ActivatedRoute){
    
  }

  ngOnInit(): void {
    const isValidParam = (param: any) => param !== null;

    var nombre= this.activeRoute.snapshot.paramMap.get('nombre') ?? '';
    var imagen= this.activeRoute.snapshot.paramMap.get('imagen') ?? '';
    var precio= parseInt(this.activeRoute.snapshot.paramMap.get('precio') ?? '');    
    
    this.producto.Set_Nombre(nombre);
    this.producto.Set_Precio(precio);
    this.producto.Set_Imagen(imagen)
  }

}
