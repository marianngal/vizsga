import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { TanuloService } from '../../services/tanulo.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-uj-tanulo.component',
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './uj-tanulo.component.html',
  styleUrl: './uj-tanulo.component.css',
})
export class TanuloUjComponent implements OnInit {
  form!: FormGroup; saving = false; error = ''; info = '';
  constructor(private fb: FormBuilder, private r: Router, private s: TanuloService) { }
  ngOnInit() {
    this.form = this.fb.group({
      nev: ['', [Validators.required, Validators.minLength(3)]],
      osztaly: ['', [Validators.required, Validators.pattern(/^\d{1,2}\.[A-Z]$/)]],
      pontszam: [0, [Validators.required, Validators.min(0), Validators.max(100)]]
    });
  }
  get nev() { return this.form.get('nev'); }
  get osztaly() { return this.form.get('osztaly'); }
  get pontszam() { return this.form.get('pontszam'); }
  submit() {
    if (this.form.invalid) { this.error = 'Töltsd ki helyesen az űrlapot.'; this.form.markAllAsTouched(); return; }
    this.saving = true;
    const v = this.form.value as { nev: string; osztaly: string; pontszam: number };
    this.s.createTanulo(v).subscribe({
      next: res => { this.saving = false; if (res.success) { this.r.navigateByUrl('/'); } else { this.error = res.message || 'Mentési hiba.'; } },
      error: _ => { this.saving = false; this.error = 'Hiba történt mentés közben.'; }
    });
  }
}
