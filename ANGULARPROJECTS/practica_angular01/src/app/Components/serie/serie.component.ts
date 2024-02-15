import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Serie from 'src/app/Models/serie';
import { SeriesService } from 'src/app/Services/series.service';

@Component({
  selector: 'app-serie',
  templateUrl: './serie.component.html'
})
export class SerieComponent implements OnInit{
  serie : Serie = new Serie();

  constructor(private _serviceSeries : SeriesService , private activeRoute : ActivatedRoute){
    
  }

  ngOnInit(): void {
    this.activeRoute.params.subscribe(response=>{
      this.serie.idSerie = parseInt(response['id']);
      this._serviceSeries.GET_Serie(this.serie.idSerie).then(response=>{    
        this.serie = Object.assign(new Serie() , response.body);
      });
    });
  }
}
