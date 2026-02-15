import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { TanuloService } from '../../services/tanulo.service';
import { Tanulo } from '../../models/tanulo';

@Component({
  selector: 'app-modosit-tanulo',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './modosit-tanulo.component.html',
  styleUrls: ['./modosit-tanulo.component.css']
})
export class ModositTanuloComponent implements OnInit {

  form!: FormGroup;
  loading = false;    // adatok betöltése az űrlaphoz
  saving = false;     // mentés folyamatban
  error = '';
  info = '';
  private id!: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private tanuloService: TanuloService
  ) { }

  ngOnInit(): void {
    // 1) ID kiolvasása az útvonalból: /modosit/:id
    this.id = Number(this.route.snapshot.paramMap.get('id'));

    if (!this.id || this.id <= 0) {
      this.error = 'Érvénytelen azonosító.';
      return;
    }

    // 2) Form üres inicializálása
    this.form = this.fb.group({
      nev: ['', [Validators.required, Validators.minLength(3)]],
      osztaly: ['', [Validators.required, Validators.pattern(/^\d{1,2}\.[A-Z]$/)]],
      pontszam: [0, [Validators.required, Validators.min(0), Validators.max(100)]]
    });

    // 3) Adatok betöltése a szerkesztéshez
    this.loadTanulo();
  }

  get nev() { return this.form.get('nev'); }
  get osztaly() { return this.form.get('osztaly'); }
  get pontszam() { return this.form.get('pontszam'); }

  loadTanulo(): void {
    this.loading = true;
    this.error = '';
    this.tanuloService.getTanulo(this.id).subscribe({
      next: (t: Tanulo) => {
        // kitöltjük az űrlapot a meglévő adatokkal
        this.form.patchValue({
          nev: t.nev,
          osztaly: t.osztaly,
          pontszam: t.pontszam
        });
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Nem sikerült betölteni a tanuló adatait.';
        this.loading = false;
      }
    });
  }

  submit(): void {
    this.error = '';
    this.info = '';

    if (this.form.invalid) {
      this.error = 'Kérlek töltsd ki helyesen az űrlapot.';
      this.form.markAllAsTouched();
      return;
    }

    const { nev, osztaly, pontszam } = this.form.value as {
      nev: string; osztaly: string; pontszam: number;
    };

    const modosított: Tanulo = {
      id: this.id,
      nev,
      osztaly,
      pontszam
    };

    this.saving = true;

    this.tanuloService.updateTanulo(modosított).subscribe({
      next: (res) => {
        this.saving = false;
        if (res.success) {
          this.info = 'Tanuló adatai módosítva.';
          this.router.navigateByUrl('/'); // vissza a listához
        } else {
          this.error = res.message || 'A módosítás nem sikerült.';
        }
      },
      error: (err) => {
        console.error(err);
        this.saving = false;
        this.error = 'Hiba történt a módosítás közben.';
      }
    });
  }
}

