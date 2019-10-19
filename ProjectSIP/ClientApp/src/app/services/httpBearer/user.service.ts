import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { UserView } from 'src/app/api/models';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/api/services';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {
  constructor(private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Apply headers
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${localStorage.getItem('token')}`
      }
    });
    return next.handle(req).pipe(
      tap(x => x, err => {

        if (err.status === 404) {
          this.router.navigate(['notfound']);
        }
        if (err.status === 401) {
          this.router.navigate(['notauth']);
        }
        if (err.status === 409) {
          this.router.navigate(['conflict', err.error]);
        }
        // Handle this error
        console.error(`Error performing request, status code = ${err.status}`);
      }));
  }
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private accountService: AccountService) { }

  IsAuthorizated(): boolean {
    if (localStorage.getItem('token')) {
      return true;
    }
    return false;
  }

  GetUserModel(): UserView {
    // return await this.accountService.apiAccountUserIdGet().toPromise();
    return null;
   }
}
