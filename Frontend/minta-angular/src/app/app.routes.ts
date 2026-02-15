import { Routes } from '@angular/router';
import { TanuloListaComponent } from './components/tanulo-lista.component/tanulo-lista.component';
import { TanuloUjComponent } from './components/uj-tanulo.component/uj-tanulo.component';
import { ModositTanuloComponent } from './components/modosit-tanulo.component/modosit-tanulo.component';

export const routes: Routes = [
    { path: "", component: TanuloListaComponent },
    { path: "uj", component: TanuloUjComponent },
    { path: "modosit/:id", component: ModositTanuloComponent }
];
