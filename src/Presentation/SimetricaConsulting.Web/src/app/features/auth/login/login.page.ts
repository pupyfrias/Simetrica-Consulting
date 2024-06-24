import { Component } from '@angular/core';
import { LoginComponent } from './login.component';

@Component({
  template: '<app-login></app-login>',
  standalone: true,
  imports: [LoginComponent]
})
export class LoginPage { }
