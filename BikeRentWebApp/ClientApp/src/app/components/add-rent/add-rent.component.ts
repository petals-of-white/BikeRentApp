import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Bicycle } from 'src/app/models/Bicycle';
import { BicycleType } from '../../models/BicycleType';
import { BikeService } from '../../services/bike.service';

@Component({
  selector: 'app-add-rent',
  templateUrl: './add-rent.component.html',
  styleUrls: ['./add-rent.component.css']
})



export class AddRentComponent implements OnInit {

  @Input()
  bicycleTypes: BicycleType[] = [];
  bikeName: string = "";

  rentPrice: number = 0;

  // bikeType: BicycleType = new BicycleType();
  bikeTypeIndex: number = 0;

  @Output() onSubmitRent: EventEmitter<Bicycle> = new EventEmitter();


  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    if (!this.bikeName) {
      alert("Please enter a name for a new bike.");
      return;
    }

    if (this.rentPrice <= 0) {
      alert("Please enter a valid rent price");
      return;
    }

    var bike: Bicycle = {
      id: 0,
      name: this.bikeName,
      rentPrice: this.rentPrice,
      bicycleType: this.bicycleTypes[this.bikeTypeIndex],
      isRented: false
    };

    console.log(bike);

    //emitting
    this.onSubmitRent.emit(bike);
  }

}
