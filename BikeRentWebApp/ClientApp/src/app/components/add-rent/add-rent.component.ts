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
  selectedType?: Bicycle;

  @Output() onSubmitRent: EventEmitter<Bicycle> = new EventEmitter();


  constructor() { }

  ngOnInit(): void {

  }

  onChange() {

  }


  onSubmit() {
    if (!this.bikeName) {
      alert("Please enter a name for a new bike.");
      return;
    }

    if (this.rentPrice <= 0) {
      alert("Please enter a valid rent price (0+).");
      return;
    }

    if (this.selectedType == null) {
      alert("Please select a bike type.");
      return;
    }

    else {
      var bike: Bicycle = {
        id: 0,
        name: this.bikeName,
        rentPrice: this.rentPrice,
        bicycleType: this.selectedType,
        isRented: false
      };
    }


    console.log(bike);

    //emitting
    this.onSubmitRent.emit(bike);
  }

}
