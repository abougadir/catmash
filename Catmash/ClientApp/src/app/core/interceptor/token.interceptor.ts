import { Injectable, Injector } from '@angular/core';
import { HttpErrorResponse, HttpInterceptor, HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import {catchError} from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(private injector: Injector) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (localStorage.getItem('access_token') != null) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${localStorage.getItem('access_token')}`
        }
      });
    }
    return next.handle(request)
    .pipe(catchError(err => {
      if (err instanceof HttpErrorResponse) {
        if (err.status === 401) {
          localStorage.removeItem('access_token');
          this.router.navigateByUrl('/login');
        }

        return [];
      }
    }));;
  }

  protected get router(): Router {
    return this.injector.get(Router);
  }
}

