import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BikesManagementComponent } from './bikes-management.component';

describe('BikesManagementComponent', () => {
  let component: BikesManagementComponent;
  let fixture: ComponentFixture<BikesManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BikesManagementComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BikesManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
