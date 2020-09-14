import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptreservationComponent } from './acceptreservation.component';

describe('AcceptreservationComponent', () => {
  let component: AcceptreservationComponent;
  let fixture: ComponentFixture<AcceptreservationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AcceptreservationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AcceptreservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
