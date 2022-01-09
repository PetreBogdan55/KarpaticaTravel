import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class ErrorInterceptorService implements HttpInterceptor {
  constructor(
    private toastrService: ToastrService,
    private authService: AuthService,
    private router: Router
  ) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      retry(1),
      catchError((err) => {
        let message = '';
        if (err.status === 401) {
          //refresh token or navigate to login
          message = 'Token has expired or you should be logged in';
          this.authService.clearToken();
          this.router.navigateByUrl('home');
        } else if (err.status === 404) {
          message = '404';
        } else if (err.status === 400) {
          //some message
          message = '400';
        } else {
          //global message for error
          message = 'Unexpected error';
        }
        this.toastrService.error(message);
        return throwError(err);
      })
    );
  }
}
