import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import Departamento from 'src/app/Models/departamento';
import { DepartamentosService } from 'src/app/Services/departamentos.service';

@Component({
  selector: 'app-form-departamento',
  templateUrl: './form-departamento.component.html'
})
export class FormDepartamentoComponent implements OnInit{
  protected method !: string;
  departamento : Departamento = new Departamento();

  constructor(private _activeRoute : ActivatedRoute , private _serviceDepartamentos : DepartamentosService){

  }

  ngOnInit(): void {
    this.method = this._activeRoute.snapshot.paramMap.get('method') as string;
    if(this.method == 'put'){
      this.departamento = Object.assign( new Departamento() ,JSON.parse(this._activeRoute.snapshot.paramMap.get('departamento') as string));
      console.log(this.departamento)
    }
  }

  Submit_Departamento(form : FormGroup) {
    this.departamento = Object.assign(new Departamento(), form.value); 
    
    if(this.method == 'put') 
      this._serviceDepartamentos.UPDATE_Departamento(this.departamento).then(response=>{console.log(response)});
    if(this.method == 'post') 
      this._serviceDepartamentos.INSERT_Departamento(this.departamento).then(response=>{console.log(response)});
    
  }

}
