import { query } from '@angular/animations';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Comic } from 'src/app/Models/Comic';

@Component({
  selector: 'app-comic',
  templateUrl: './comic.component.html'
})
export class ComicComponent {
  @Input() comic !: Comic; 
  @Output() eliminar: EventEmitter<Comic> = new EventEmitter<Comic>();
  @Output() favorito: EventEmitter<Comic> = new EventEmitter<Comic>();
  
  constructor(private router : Router){
  }

  Boton_Delete(){
    this.eliminar.emit(this.comic);
  }
  Boton_Favorito(){
    this.favorito.emit(this.comic);
  }
  Boton_Detalles() {
    this.router.navigate(['/comic/detalles'], 
                            { 
                              queryParams : { comic : JSON.stringify(this.comic)}
                            }
                          );
  }
  Boton_Modificar() {
    this.router.navigate(['/comic/put'], 
    { 
      queryParams : { comic : JSON.stringify(this.comic)}
    }
  );
  }
}
