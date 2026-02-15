import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UjTanuloComponent } from './uj-tanulo.component';

describe('UjTanuloComponent', () => {
  let component: UjTanuloComponent;
  let fixture: ComponentFixture<UjTanuloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UjTanuloComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UjTanuloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
