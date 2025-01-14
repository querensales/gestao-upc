import { Component } from '@angular/core';
import LoginModel from '../../models/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  objetoLogin: LoginModel = new LoginModel();

  entrar(): void {
    this.objetoLogin.email = 'colocar o valor do input aqui';
    this.objetoLogin.password = 'colocar o valor do input aqui';
  }

}
