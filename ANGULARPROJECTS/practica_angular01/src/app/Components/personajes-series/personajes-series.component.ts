import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Personaje from 'src/app/Models/personaje';
import { SeriesService } from 'src/app/Services/series.service';

@Component({
  selector: 'app-personajes-series',
  templateUrl: './personajes-series.component.html'
})
export class PersonajesSeriesComponent implements OnInit{
  personajes : Array<Personaje> = [];

  constructor(private _servicePersonajes : SeriesService , private activatedRoute : ActivatedRoute){

  }

  ngOnInit(): void {
    var id : number = (this.activatedRoute.snapshot.paramMap.get('id') ?? NaN) as number;
    this._servicePersonajes.GET_Personajes_Serie(id).then(response=>{
      response.body.forEach((personaje : Personaje) => {
        this.personajes.push(personaje);
      });
    });
  }

}
