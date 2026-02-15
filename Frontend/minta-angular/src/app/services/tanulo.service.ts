// src/app/services/tanulo.service.ts
// Feladata: TANULÓK REST API hívásai (lista + új felvétel + módosítás + törlés)

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tanulo } from '../models/tanulo';

@Injectable({
  providedIn: 'root'
})
export class TanuloService {

  // LISTA (összes tanuló)
  private readonly listUrl = 'http://localhost/minta_api/tanulok.php';

  // ÚJ FELVÉTEL
  private readonly createUrl = 'http://localhost/minta_api/tanulok_create.php';

  // MÓDOSÍTÁS + EGY TANULÓ LEKÉRÉSE (mindkettőt ez a PHP intézi)
  private readonly updateUrl = 'http://localhost/minta_api/tanulok_update.php';

  // TÖRLÉS
  private readonly deleteUrl = 'http://localhost/minta_api/tanulok_delete.php';

  constructor(private http: HttpClient) { }

  /** Összes tanuló lekérése */
  getTanulok(): Observable<Tanulo[]> {
    return this.http.get<Tanulo[]>(this.listUrl);
  }

  /** Új tanuló létrehozása */
  createTanulo(body: { nev: string; osztaly: string; pontszam: number })
    : Observable<{ success: boolean; id?: number; message?: string }> {

    return this.http.post<{ success: boolean; id?: number; message?: string }>(
      this.createUrl,
      body
    );
  }

  /** Egy tanuló lekérése ID alapján (szerkesztő űrlaphoz) */
  getTanulo(id: number): Observable<Tanulo> {
    return this.http.get<Tanulo>(`${this.updateUrl}?id=${id}`);
  }

  /** Tanuló módosítása (UPDATE) */
  updateTanulo(t: Tanulo): Observable<{ success: boolean; message?: string }> {
    // a backend { id, nev, osztaly, pontszam } JSON-t vár
    return this.http.post<{ success: boolean; message?: string }>(
      this.updateUrl,
      t
    );
  }

  /** Tanuló törlése ID alapján */
  deleteTanulo(id: number): Observable<{ success: boolean; message?: string }> {
    return this.http.post<{ success: boolean; message?: string }>(
      this.deleteUrl,
      { id }
    );
  }
}
