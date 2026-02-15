import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Szavazat } from './szavazat';

describe('Szavazat', () => {
  let component: Szavazat;
  let fixture: ComponentFixture<Szavazat>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Szavazat]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Szavazat);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
