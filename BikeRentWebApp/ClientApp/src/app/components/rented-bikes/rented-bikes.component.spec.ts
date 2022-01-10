import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentedBikesComponent } from './rented-bikes.component';

describe('RentedBikesComponent', () => {
  let component: RentedBikesComponent;
  let fixture: ComponentFixture<RentedBikesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RentedBikesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RentedBikesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
