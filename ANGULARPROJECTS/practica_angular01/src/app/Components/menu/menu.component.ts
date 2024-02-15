import { Component, OnInit } from '@angular/core';
import Serie from 'src/app/Models/serie';
import { SeriesService } from 'src/app/Services/series.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent implements OnInit{
  series : Array<Serie> = [];

  constructor(private serviceSeries: SeriesService ){}

  ngOnInit(): void {
    this.Get_Series();
  }

  Get_Series() : void{
    this.series = [];
    this.serviceSeries.GET_Series().then(response=>{
      response.body.forEach((serie : Serie) => {
        this.series.push(Object.assign(new Serie(), serie));
      });      
    });
  }

}
