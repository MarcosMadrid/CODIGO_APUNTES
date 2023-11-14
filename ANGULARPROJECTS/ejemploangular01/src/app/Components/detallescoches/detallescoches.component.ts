import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Coche } from '../../Models/Coche';

@Component({
  selector: 'app-detallescoches',
  templateUrl: './detallescoches.component.html'
})
export class DetallescochesComponent implements OnInit {
  @Input() coche !: Coche;
  @Output() eliminar: EventEmitter<number> = new EventEmitter<number>();
  @Input() id !: number;

  onDeleteClick() {
    this.eliminar.emit(this.id);
  }

  ngOnInit(): void {
    
  }
}
