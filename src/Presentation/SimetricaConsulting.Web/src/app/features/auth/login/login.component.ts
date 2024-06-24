import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { Router, RouterModule } from '@angular/router';
import { LoginRequest, LoginResponse } from '@models/login';
import { AuthService } from '@services/auth.service';
import { MessageService } from '@services/message.service';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatIconModule,
    RouterModule
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  hide = true;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private messageService: MessageService
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  ngOnInit(): void { }

  onSubmit(): void {
    if (this.loginForm.valid) {
      const { email, password } = this.loginForm.value;
      const loginRequest: LoginRequest = { email, password };

      this.authService.login(loginRequest).subscribe({
        next: (response: LoginResponse) => {
          if (response.roles.includes('Admin')) {
            localStorage.setItem('role', 'admin');
          }
          localStorage.setItem('token', response.accessToken);
          localStorage.setItem('userId', response.id);
          this.messageService.showSuccess('Login successful!');
          this.router.navigate(['/dashboard']);
        }
      });
    }
  }

  togglePasswordVisibility() {
    this.hide = !this.hide;
  }
}
