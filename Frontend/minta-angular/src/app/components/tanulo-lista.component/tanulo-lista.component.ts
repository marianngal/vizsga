import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { TanuloService } from '../../services/tanulo.service';
import { Tanulo } from '../../models/tanulo';

@Component({
  selector: 'app-tanulo-lista',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './tanulo-lista.component.html',
  styleUrls: ['./tanulo-lista.component.css']
})
export class TanuloListaComponent implements OnInit {

  tanulok: Tanulo[] = [];
  loading = false;
  error = '';
  info = '';

  constructor(private tanuloService: TanuloService) { }

  ngOnInit(): void {
    this.loadTanulok();
  }

  loadTanulok(): void {
    this.loading = true;
    this.error = '';
    this.info = '';

    this.tanuloService.getTanulok().subscribe({
      next: (data) => {
        this.tanulok = data;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Hiba történt az adatok lekérésekor.';
        this.loading = false;
      }
    });
  }

  onDelete(t: Tanulo): void {
    // 1) megerősítés
    const confirmed = window.confirm('Biztos szeretnéd törölni az elemet?');
    if (!confirmed) return;

    // 2) hívás + UI frissítés
    this.error = '';
    this.info = '';

    this.tanuloService.deleteTanulo(t.id).subscribe({
      next: (res) => {
        if (res?.success) {
          this.tanulok = this.tanulok.filter(x => x.id !== t.id);
          this.info = 'Rekord törölve.';
        } else {
          this.error = res?.message || 'A törlés nem sikerült.';
        }
      },
      error: (err) => {
        console.error(err);
        this.error = 'Hiba történt a törlés során. Ellenőrizd az API végpontot és az ID-t!';
      }
    });
  }
}
