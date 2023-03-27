import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import {catchError, delay, Observable, throwError} from 'rxjs';
import {Router} from "@angular/router";
import {ToastsService} from "../../toasts/toasts.service";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastsService: ToastsService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      delay(0),
      catchError(err => {
        if (err.status === 400 || err.status === 404 || this.is5xx(err.status)) {
          this.toastsService.warning(err.error.title, err.error.detail);
        }

        if (err.status === 404){
          this.router.navigateByUrl('not-found');
        }

        return throwError(err);
      })
    )
  }

  is5xx(status: number) {
    return status >= 500 && status < 600;
  }
}
