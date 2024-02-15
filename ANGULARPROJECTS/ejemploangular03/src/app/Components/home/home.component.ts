import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Departamento from 'src/app/Models/departamento';
import { DepartamentosService } from 'src/app/Services/departamentos.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit{
  public departamentos : Array<Departamento> = []
  constructor(private _servideDepartapentos : DepartamentosService, private router : Router){}

  ngOnInit(): void {
    this._servideDepartapentos.GET_Departamentos()
      .then(response=>{
        (response.body).forEach((dept : Object) => {
          this.departamentos.push(Object.assign(new Departamento(),dept));          
        });
      })
      .catch(error=>{
        console.log(error.message);
      });
  }

  Btn_Modificar(departamento: Departamento) {
    this.router.navigate([ '/departamento' , 
                            'put',                         
                            JSON.stringify(departamento)]);
  }
} 
