import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddnewdestinationComponent } from './addnewdestination.component';

describe('AddnewdestinationComponent', () => {
  let component: AddnewdestinationComponent;
  let fixture: ComponentFixture<AddnewdestinationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddnewdestinationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddnewdestinationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
