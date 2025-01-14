import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './pages/login/login.component';

@NgModule({
  declarations: [
    LoginComponent
  ],
  
  imports: [
    CommonModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ]
})
export class AppModule { }
