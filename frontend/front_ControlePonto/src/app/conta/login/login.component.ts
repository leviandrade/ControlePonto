import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Login } from '../models/login';
import { LoginService } from '../services/login.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm!: FormGroup;
  login: Login = new Login();
  errors: any[] = [];


  constructor(
    private fb:FormBuilder,
    private toastr: ToastrService,
    private loginService:LoginService) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      Cpf: ['', [Validators.required, Validators.min(11)]],
      Senha: ['', [Validators.required]]
    });
  }

  efetuarLogin(){
    this.login = Object.assign({}, this.login, this.loginForm.value);
    this.loginService.login(this.login)
    .subscribe(
      sucesso => { this.processarSucesso(sucesso) },
      falha => { this.processarFalha(falha) }
    );
  }
  processarSucesso(response: any) {
    alert("Sucesso");
    console.log(response);
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    console.log(this.errors);
    this.toastr.error(this.errors.join("<br/>"));

  }

}
