import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SackComponent } from './sack.component';

describe('SackComponent', () => {
  let component: SackComponent;
  let fixture: ComponentFixture<SackComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SackComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
