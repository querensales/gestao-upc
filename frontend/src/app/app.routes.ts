import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { EsqueceuSenhaComponent } from './pages/esqueceu-senha/esqueceu-senha.component';
import { NgModule } from '@angular/core';


export const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path:'home', component: HomeComponent},
  {path:'home', component: HomeComponent},
  {path:'esqueceuSenha', component: EsqueceuSenhaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
