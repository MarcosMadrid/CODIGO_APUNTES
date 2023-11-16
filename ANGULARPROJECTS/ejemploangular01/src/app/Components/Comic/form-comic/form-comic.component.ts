import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm} from '@angular/forms';
import { Comic } from 'src/app/Models/Comic';

@Component({
  selector: 'app-form-comic',
  templateUrl: './form-comic.component.html'
})
export class FormComicComponent{
  method !: string;  
  comic : Comic = new Comic();

  constructor(private activeRoute:ActivatedRoute, private router:Router){
    this.method = this.activeRoute.snapshot.paramMap.get('method') ?? 'post';
    
    if(this.activeRoute.snapshot.queryParamMap.get('comic')){
      this.comic = Object.assign(new Comic(), JSON.parse(this.activeRoute.snapshot.queryParamMap.get('comic') ?? ''));
    }
  }
  
  SubmitComic(form: NgForm) {   
    if(form.status != 'VALID'){
      return;
    }
    var comic : Comic = Object.assign(new Comic(),form.value['comic']);   
    
    this.router.navigate(['/comics', JSON.stringify(comic)])
  }

}
