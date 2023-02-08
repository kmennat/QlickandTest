import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { DatenschuztComponent } from './components/datenschuzt/datenschuzt.component';
import { ImpressumComponent } from './components/impressum/impressum.component';

const routes: Routes = [
  {
    path:'', component:MainComponent
  },
  {
    path:'date', component:DatenschuztComponent
  },
  {
    path:'impressum', component:ImpressumComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
