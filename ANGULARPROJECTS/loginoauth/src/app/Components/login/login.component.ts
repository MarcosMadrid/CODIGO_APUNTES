import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import User from 'src/app/Models/user';
import { EmpleadosService } from 'src/app/Services/empleados.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {

  constructor(private _serviceEmpleados : EmpleadosService, private router : Router){}

  Submit_Login(form: FormGroup<any>) {    
    if(form.status == 'INVALID')
      return;
    var user: User = Object.assign(new User(), form.value);
    this._serviceEmpleados.GET_TOKEN(user).then((response : any)=>{
      var token = response.body.response;
      if(response.status == 200){
        Swal.fire({
          icon: "success",
          title: "Login con exito",
          text: "Se ha iniciado sesión con "+ user.Get_userName(), 
        });
        this.router.navigate(['/empleados', token]);
      }else{
        Swal.fire({
          icon: "error",
          title: "Oops...",
          text: "Something went wrong!",
          footer: '<a href="#">Why do I have this issue?</a>'
        });
      }
    });    
  }

}
