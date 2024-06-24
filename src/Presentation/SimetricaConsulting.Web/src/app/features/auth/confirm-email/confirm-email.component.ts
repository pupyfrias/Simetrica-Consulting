import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@services/auth.service';
import { MessageService } from '@services/message.service';

@Component({
  selector: 'app-confirm-email',
  standalone: true,
  imports: [MatCardModule],
  templateUrl: './confirm-email.component.html',
  styleUrl: './confirm-email.component.css'
})
export class ConfirmEmailComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    private router: Router,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    const userId = this.route.snapshot.queryParamMap.get('userId');
    const token = this.route.snapshot.queryParamMap.get('token');

    if (userId && token) {
      this.authService.confirmEmail(userId, token).subscribe({
        next: () => {
          this.router.navigate(['/auth/login']);
        }
      });
    } else {
      this.messageService.showError('User ID or token is missing');
      console.error('User ID or token is missing');
    }
  }
}
