import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { LoginPage } from './login/login.page';
import { RegisterPage } from './register/register.page';
import { LoginGuard } from 'src/app/core/guards/login.guard';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';
import { NotFoundComponent } from 'src/app/not-found/not-found.component';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: 'login', component: LoginPage, canActivate:[LoginGuard] },
      { path: 'register', component: RegisterPage, canActivate:[LoginGuard] },
      { path: 'confirm-email', component: ConfirmEmailComponent,canActivate:[LoginGuard] },
      { path: '**', component: NotFoundComponent }
    ])
  ]
})
export class AuthModule { }
