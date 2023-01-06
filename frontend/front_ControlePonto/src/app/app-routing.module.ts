import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContaGuard } from './services/conta.guard';

const routes: Routes = [
  {
    path: 'conta',
    loadChildren: () => import('./conta/conta.module')
      .then(m => m.ContaModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
