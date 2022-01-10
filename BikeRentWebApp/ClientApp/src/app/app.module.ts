import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { AddRentComponent } from './components/add-rent/add-rent.component';
import { RentedBikesComponent } from './components/rented-bikes/rented-bikes.component';
import { AvailableBikesComponent } from './components/available-bikes/available-bikes.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    AddRentComponent,
    RentedBikesComponent,
    AvailableBikesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
