import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatenschuztComponent } from './datenschuzt.component';

describe('DatenschuztComponent', () => {
  let component: DatenschuztComponent;
  let fixture: ComponentFixture<DatenschuztComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DatenschuztComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DatenschuztComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
