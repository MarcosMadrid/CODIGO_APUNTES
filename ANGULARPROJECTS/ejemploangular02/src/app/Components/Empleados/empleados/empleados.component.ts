import { Component, OnInit } from '@angular/core';
import Empleado from 'src/app/Models/empleados';
import { EmpleadosService } from 'src/app/Services/empleados.service';

@Component({
  selector: 'app-empleados',
  templateUrl: './empleados.component.html'
})
export class EmpleadosComponent implements OnInit{
  empleados : Array<Empleado> = []; 
  funciones : Array<string> = [];
  constructor(private _serviceEmpleados : EmpleadosService){    
  }

  ngOnInit(): void {
    this._serviceEmpleados.GET_Funciones()
    .then(response=>{
      this.funciones = response as Array<string>;
    })
    .catch(error=>{
      console.log(error);
    });
  }

  Submit_Funcion(selector : any){
    this.empleados = [];
    var funciones : Array<string> = selector.viewModel

    funciones.forEach(funcion => {
      this._serviceEmpleados.GET_EmpleadosFunciones(funcion)
      .then((response : Array<Empleado>) =>{
        response.forEach((empleado: Empleado) => {          
          this.empleados.push(Object.assign(new Empleado() , empleado));
        });       
      });
    });    
  }
}
