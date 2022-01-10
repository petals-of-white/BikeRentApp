import { Component, OnInit } from '@angular/core';
import { Bicycle } from 'src/app/models/Bicycle';
import { BikeService } from 'src/app/services/bike.service';
import { BicycleType } from '../../models/BicycleType';

@Component({
  selector: 'app-bikes-management',
  templateUrl: './bikes-management.component.html',
  styleUrls: ['./bikes-management.component.css']
})
export class BikesManagementComponent implements OnInit {

  bicycles: Bicycle[] = [];


  availableBicycles: Bicycle[] = [];
  rentedBicycles: Bicycle[] = [];
  allBicycleTypes: BicycleType[] = [];


  constructor(private bikeService: BikeService) {
  }


  updateAllBicycles() {
    this.bikeService.getAllBicycles().subscribe(
      (b) => {
        console.log(b);
        this.bicycles = b;
        this.updateBothAvailableAndRented();
      }
    );
  }

  ngOnInit(): void {


    this.updateAllBicycles();

    this.bikeService.getAllBicycleTypes().subscribe(
      bt => {
        console.log(bt);
        this.allBicycleTypes = bt;
      }
    )

  }

  test() {
    console.log("Усі велосипеди:")
    console.log(this.bicycles);

    console.log("вільні: не в змінній");
    console.log(this.bicycles.filter(b => b.isRented === false))

    console.log("до");
    console.log(this.availableBicycles);

    this.updateAvailableBicycles();

    console.log("після");
    console.log(this.availableBicycles);


    console.log(this.bicycles.filter(b => b.isRented === true))
    //console.log(this.bicycles);
    //console.log(this.availableBicycles);
    //console.log(this.rentedBicycles);

    //this.availableBicycles.push(new Bicycle());
  }

  updateAvailableBicycles() {
    this.availableBicycles = this.bicycles.filter(b => b.isRented === false);
  }

  updateRentedBicycles() {
    this.rentedBicycles = this.bicycles.filter(b => b.isRented === true);
  }

  updateBothAvailableAndRented() {
    this.updateAvailableBicycles();
    this.updateRentedBicycles();
  }

  deleteBicycle(bicycle: Bicycle) {
    console.log("Deleting bike number" + bicycle.id);
    this.bikeService.deleteBicycle(bicycle).subscribe(
      () => {
        this.bicycles = this.bicycles.filter(b => b.id !== bicycle.id);
        this.updateBothAvailableAndRented();
      }
    );

    
  }

  addBicycle(bicycle: Bicycle) {
    this.bikeService.addBicycle(bicycle).subscribe(
      () => {
        this.updateAllBicycles();
      }
    );
  }

  rentBicycle(bicycle: Bicycle) {
    this.bikeService.rentBicycle(bicycle).subscribe(
      () => {
        bicycle.isRented = true;
        this.updateBothAvailableAndRented();
      }
    );

    
  }

  cancelRent(bicycle: Bicycle) {
    this.bikeService.cancelRent(bicycle).subscribe(
      () => {
        bicycle.isRented = false;
        this.updateBothAvailableAndRented();
      }
    );
  }

  // submitRent(bicycle: Bicycle)
  // {
  //   this.bikeService.addBicycle(bicycle).subscribe(
  //     b => {
  //       this.bicycles.push
  //     } 
  //   );
  // }

}
