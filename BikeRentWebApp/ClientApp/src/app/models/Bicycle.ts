import { BicycleType } from "./BicycleType";

export class Bicycle {
  id: number = 0;
  name: string = "";
  rentPrice: number = 0;
  isRented: boolean = false;
  bicycleType: BicycleType = new BicycleType();

  constructor() {

  };

}
