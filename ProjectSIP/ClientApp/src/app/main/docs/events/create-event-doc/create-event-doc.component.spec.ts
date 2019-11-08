import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEventDocComponent } from './create-event-doc.component';

describe('CreateEventDocComponent', () => {
  let component: CreateEventDocComponent;
  let fixture: ComponentFixture<CreateEventDocComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateEventDocComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateEventDocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
