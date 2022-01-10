import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Bicycle } from 'src/app/models/Bicycle';

@Component({
  selector: 'app-available-bikes',
  templateUrl: './available-bikes.component.html',
  styleUrls: ['./available-bikes.component.css']
})
export class AvailableBikesComponent implements OnInit {

  @Input() availableBicycles: Bicycle[] = [];


  @Output() onDeleteBicycle: EventEmitter<Bicycle> = new EventEmitter();

  @Output() onRentBicycle: EventEmitter<Bicycle> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {

  }

  onDelete(bicycle: Bicycle) {
    this.onDeleteBicycle.emit(bicycle);
  }
  onRent(bicycle: Bicycle) {
    this.onRentBicycle.emit(bicycle);
  }

}
