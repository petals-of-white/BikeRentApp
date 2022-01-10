import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Bicycle } from 'src/app/models/Bicycle';

@Component({
  selector: 'app-rented-bikes',
  templateUrl: './rented-bikes.component.html',
  styleUrls: ['./rented-bikes.component.css']
})
export class RentedBikesComponent implements OnInit {


  @Input() rentedBicycles: Bicycle[] = [];

  @Output() onCancelRent: EventEmitter<Bicycle> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  onCancel(bicycle: Bicycle) {
    this.onCancelRent.emit(bicycle);
  }

}
