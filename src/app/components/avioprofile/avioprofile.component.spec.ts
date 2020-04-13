import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AvioprofileComponent } from './avioprofile.component';

describe('AvioprofileComponent', () => {
  let component: AvioprofileComponent;
  let fixture: ComponentFixture<AvioprofileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AvioprofileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AvioprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
