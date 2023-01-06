import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { ContaAppComponent } from './conta.app.component';
import { RouterModule } from '@angular/router';
import { ContaRoutingModule } from './conta.route';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginService } from './services/login.service';
import { ContaGuard } from '../services/conta.guard';



@NgModule({
  declarations: [
    ContaAppComponent,
    LoginComponent,
    UsuarioComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ContaRoutingModule,
    ReactiveFormsModule
  ],
  providers:[
    LoginService
  ]
})
export class ContaModule { }
