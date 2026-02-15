import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModositTanuloComponent } from './modosit-tanulo.component';

describe('ModositTanuloComponent', () => {
  let component: ModositTanuloComponent;
  let fixture: ComponentFixture<ModositTanuloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModositTanuloComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModositTanuloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
