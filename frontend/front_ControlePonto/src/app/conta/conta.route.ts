import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContaGuard } from '../services/conta.guard';
import { ContaAppComponent } from './conta.app.component';
import { LoginComponent } from './login/login.component';
import { UsuarioComponent } from './usuario/usuario.component';

const contaRouterConfig: Routes = [
    {
        path: '', component: ContaAppComponent,
        children: [
            { path: 'login', component: LoginComponent},
            { path: 'usuario', component: UsuarioComponent, canActivate:[ContaGuard] }
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(contaRouterConfig)
    ],
    exports: [RouterModule]
})
export class ContaRoutingModule { }