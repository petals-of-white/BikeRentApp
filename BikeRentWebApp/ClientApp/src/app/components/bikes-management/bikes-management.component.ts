import { Component, DoBootstrap, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Bicycle } from 'src/app/models/Bicycle';
import { BikeService } from 'src/app/services/bike.service';
import { BicycleType } from '../../models/BicycleType';

declare var $: any;

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



  @ViewChild('bikeAdded')
    bikeAddedModal!: ElementRef;
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

    this.updateAllBicycleTypes();
    this.updateAllBicycles();
  }

  updateAllBicycleTypes() {
    this.bikeService.getAllBicycleTypes().subscribe(
      bt => {
        console.log(bt);
        this.allBicycleTypes = bt;
      }
    );
  }

  test() {

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
        var bikeModal = $("#bikeAdded");
        try {
          bikeModal.modal('show');
        }
        catch (e) {
          
          alert((e as Error).message);
        }
        
        //let bikeAddedModal = <any>document.getElementById("bikeAdded");
        //if (bikeAddedModal === null) {
        //  alert("Modal not found!");
        //}
        //else {
        //  bikeAddedModal.modal("toggle");
        //}
        
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
