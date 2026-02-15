import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Hiba } from './hiba';

describe('Hiba', () => {
  let component: Hiba;
  let fixture: ComponentFixture<Hiba>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Hiba]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Hiba);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
