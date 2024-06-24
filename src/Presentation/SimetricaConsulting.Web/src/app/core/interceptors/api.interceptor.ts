import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, map, throwError } from 'rxjs';
import { MessageService } from '@services/message.service';


@Injectable({
  providedIn: 'root'
})
export class ApiInterceptor implements HttpInterceptor {

  constructor(private messageService: MessageService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      map(event => {
        if (event instanceof HttpResponse) {
          if (event.body && event.body.success && event.body.data) {
            return event.clone({ body: event.body.data });
          } else if (event.body && event.body.success && !event.body.data) {

            this.messageService.showSuccess(event.body.message);
          }
        }
        return event;
      }),
      catchError((error: HttpErrorResponse) => {
        return throwError(() => new Error('Something bad happened; please try again later.'));
      })
    );
  }
}
