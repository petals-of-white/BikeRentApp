import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Bicycle } from "../models/Bicycle"
import {BicycleType} from "../models/BicycleType"
import { Location } from "@angular/common";

const httpOptions =
{
  headers: new HttpHeaders(
    {
      'Content-Type': 'application/json'
    }
  )
}

export enum RentAction {
  Rent,
  CancelRent
}

@Injectable({
  providedIn: 'root'
})

export class BikeService {

  
  private apiURL!: string;
  constructor(private http: HttpClient, private location: Location) {
    this.apiURL = this.location.path() + "/api/bicycle/";
  }


  getAllBicycles(): Observable<Bicycle[]> {
    let output = this.http.get<Bicycle[]>(this.apiURL);
    return output;
  }

  getAllBicycleTypes(): Observable<BicycleType[]> {
    let output = this.http.get<BicycleType[]>(this.apiURL + "types");
    return output;
  }
  getBicycle(id: number): Observable<Bicycle> {
    let output = this.http.get<Bicycle>(this.apiURL+id);
    return output;
  }

  rentBicycle(bicycle: Bicycle): Observable<Bicycle> {

    return this.http.put<Bicycle>(this.apiURL + bicycle.id, RentAction.Rent);
  }

  cancelRent(bicycle: Bicycle): Observable<Bicycle> {

    return this.http.put<Bicycle>(this.apiURL+bicycle.id, RentAction.CancelRent);

  }

  addBicycle(bicycle: Bicycle): Observable<Bicycle> {
    return this.http.post<Bicycle>(this.apiURL, bicycle, httpOptions);
  }
  deleteBicycle(bicycle: Bicycle): Observable<Bicycle> {
    return this.http.delete<Bicycle>(this.apiURL+bicycle.id);
  }

  
  
}
