import { Component } from '@angular/core';
import LoginModel from '../../models/login.model';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { HttpClientModule } from '@angular/common/http';


@Component({
  imports: [FormsModule, RouterModule,HttpClientModule],
  providers: [AccountService],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private accountService: AccountService) { }
  model: LoginModel = new LoginModel();
  valorDoEmail = '';
  valorDaSenha: string = '';

  entrar(): void {
    this.model.email = this.valorDoEmail;
    this.model.password = this.valorDaSenha;

    this.accountService.login(this.model).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error.error);
      }
    );
  }

}
