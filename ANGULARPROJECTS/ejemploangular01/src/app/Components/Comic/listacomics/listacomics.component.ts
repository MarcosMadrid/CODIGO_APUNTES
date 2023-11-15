import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Comic } from 'src/app/Models/Comic';
import { ComicsService } from 'src/app/services/comics.service';

@Component({
  selector: 'app-listacomics',
  templateUrl: './listacomics.component.html'
})
export class ListacomicsComponent implements OnInit {
  comics : Array<Comic> = [];
  favorito !: Comic;

  constructor(private activatedRoute:ActivatedRoute, private service_Comics: ComicsService){
    
  }

  ngOnInit(): void {
    this.comics = this.service_Comics.GET_Comics();
    if(this.activatedRoute.snapshot.paramMap.get('comic')  != null){
      var comic : Comic = Object.assign(new Comic(),JSON.parse(this.activatedRoute.snapshot.paramMap.get('comic') ?? ''));
      this.comics.push(comic);
    }    
  }

  SelectFavorito(comic : Comic){
    this.favorito = comic;
  }

  Delete_Comic(comic :Comic){
    this.comics.splice(this.comics.indexOf(comic),1);
  }

  Insert_Comic(comic : Comic){
    this.comics.push(comic)
  }

  Update_Comic(comic : Comic , id : number){
    this.comics[id] = comic;
  }
  
}
