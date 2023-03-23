import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import {catchError, Observable, throwError} from 'rxjs';
import {Router} from "@angular/router";
import {ToastsService} from "../toasts-system/toasts.service";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastsService: ToastsService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError(err => {
        if (err.status === 400 || this.is5xx(err.status)) {
          this.toastsService.warning(err.error.title, err.error.detail);
        }

        return throwError(err);
      })
    )
  }

  is5xx(status: number) {
    return status >= 500 && status < 600;
  }
}
