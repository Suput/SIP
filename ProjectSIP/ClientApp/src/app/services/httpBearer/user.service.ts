import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Apply headers
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${localStorage.getItem('token')}`
      }
    });
    return next.handle(req).pipe(
      tap(x => x, err => {
        // Handle this error
        console.error(`Error performing request, status code = ${err.status}`);
      })
    );
  }
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  IsAuthorizated() {
    if (localStorage.getItem('token')) {
      return true;
    }
    return false;
  }
}
