import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Szavazat } from './szavazat/szavazat';
import { Hiba } from './hiba/hiba';

const routes: Routes = [
  {path: "Szavazat", component: Szavazat},
  {path: "Hiba", component: Hiba},
  {path: "", redirectTo: "/Szavazat", pathMatch: "full" },
  {path: "**", component: Hiba}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
