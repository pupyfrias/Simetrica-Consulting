import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthService } from '@services/auth.service';
import { MessageService } from '@services/message.service';

@Injectable(
  {
    providedIn: 'root'
  }
)
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    private router: Router,
    private authService: AuthService,
    private messageService: MessageService
  ) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = '';

        if (error.error instanceof ErrorEvent) {
          errorMessage = `Error: ${error.error.message}`;
        } else {
          errorMessage = `Status Code: ${error.status}\n${error.error.message}`;
        }

        if (error.status === 401) {
          this.authService.logout();
          this.router.navigate(['/auth/login']);
        }

        this.messageService.showError(errorMessage);
        return throwError(() => new Error(errorMessage));
      })
    );
  }
}
