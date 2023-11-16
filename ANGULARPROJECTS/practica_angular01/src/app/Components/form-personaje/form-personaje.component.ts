import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import Personaje from 'src/app/Models/personaje';
import Serie from 'src/app/Models/serie';
import { SeriesService } from 'src/app/Services/series.service';

@Component({
  selector: 'app-form-personaje',
  templateUrl: './form-personaje.component.html'
})
export class FormPersonajeComponent {
  series: Array<Serie> = [];
  personaje !: Personaje;

  constructor(private serviceSeries: SeriesService , private route : Router){}

  ngOnInit(): void {
    this.Get_Series();
  }

  Get_Series(): void{
  this.series = [];
  this.serviceSeries.GET_Series().then((response: { body: Serie[]; })=>{
    response.body.forEach((serie : Serie) => {
      this.series.push(Object.assign(new Serie(), serie));
    });      
  });
  }

  Submit_Personaje(form: FormGroup<any>) {
    this.personaje = Object.assign(new Personaje(), form.value);
    this.route.navigate(['/personajes/'+ this.personaje.idSerie]);
  }

}
