import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';


import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { AddRentComponent } from './components/add-rent/add-rent.component';
import { RentedBikesComponent } from './components/rented-bikes/rented-bikes.component';
import { AvailableBikesComponent } from './components/available-bikes/available-bikes.component';
import { BikesManagementComponent } from './components/bikes-management/bikes-management.component';
//import { RouterModule, Routes } from '@angular/router';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    AddRentComponent,
    RentedBikesComponent,
    AvailableBikesComponent,
    BikesManagementComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
