import { Component } from '@angular/core';
import { RegisterComponent } from './register.component';

@Component({
  template: '<app-register></app-register>',
  standalone: true,
  imports: [RegisterComponent]

})
export class RegisterPage { }
