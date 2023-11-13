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

    var nombre= String(this.activeRoute.snapshot.paramMap.get('nombre'));
    var imagen= String(this.activeRoute.snapshot.paramMap.get('imagen'));
    var precio= parseInt(this.activeRoute.snapshot.paramMap.get('precio') ?? '');    
    
    this.producto = new Producto(
      nombre,
      imagen,
      precio
    );    
  }

}
