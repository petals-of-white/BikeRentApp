import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvailableBikesComponent } from './available-bikes.component';

describe('AvailableBikesComponent', () => {
  let component: AvailableBikesComponent;
  let fixture: ComponentFixture<AvailableBikesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AvailableBikesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AvailableBikesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
