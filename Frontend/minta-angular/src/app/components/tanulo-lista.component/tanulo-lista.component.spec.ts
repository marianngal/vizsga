import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TanuloListaComponent } from './tanulo-lista.component';

describe('TanuloListaComponent', () => {
  let component: TanuloListaComponent;
  let fixture: ComponentFixture<TanuloListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TanuloListaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TanuloListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
