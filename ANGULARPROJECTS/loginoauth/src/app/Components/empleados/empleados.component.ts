import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Empleado from 'src/app/Models/empleado';
import { EmpleadosService } from 'src/app/Services/empleados.service';

@Component({
  selector: 'app-empleados',
  templateUrl: './empleados.component.html'
})
export class EmpleadosComponent implements OnInit {
  empleados !: Array<Empleado>;

  constructor(private _serviceEmpleados : EmpleadosService , private _activeRoute : ActivatedRoute ){}

  ngOnInit(): void { 
     this.empleados = [];
    this._serviceEmpleados.GET_Empleados(this._activeRoute.snapshot.paramMap.get('token') ?? '').then(response=>{
      response.body.forEach((empleado : Empleado) => {
        Object.assign(new Empleado(), empleado);
        this.empleados.push(empleado);
      });      
    });
  }
}
