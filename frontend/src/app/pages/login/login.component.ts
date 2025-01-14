import { Component } from '@angular/core';
import LoginModel from '../../models/login.model';
import { FormsModule } from '@angular/forms';

@Component({
  imports: [FormsModule],
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor() { }
  objetoLogin: LoginModel = new LoginModel();
  valorDoEmail = '';
  valorDaSenha: string = '';

  entrar(): void {
    this.objetoLogin.email = this.valorDoEmail;
    this.objetoLogin.password = this.valorDaSenha;
    console.log(this.objetoLogin)
  }

}
