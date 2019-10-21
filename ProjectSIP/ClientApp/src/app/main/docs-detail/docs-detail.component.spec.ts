import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DocsDetailComponent } from './docs-detail.component';

describe('DocsDetailComponent', () => {
  let component: DocsDetailComponent;
  let fixture: ComponentFixture<DocsDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DocsDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DocsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
