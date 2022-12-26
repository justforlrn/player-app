import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { TDSNotificationService } from 'tds-ui/notification';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class HttpCustomSharedService {
  //private options: any;
  apiUrl = environment.apiUrl;
  constructor(
    private http: HttpClient,
    private notification: TDSNotificationService,
    private router: Router
  ) {}

  get options() {
    // eslint-disable-next-line prefer-const
    let _options: any = {};
    _options.headers = new HttpHeaders({
      'Content-Type': 'application/json',
      // Authorization: `Bearer ${this.localStorageService.userAccessToken}`,
    });
    return _options;
  }

  public request(method: string, url: string, options?: any): Observable<any> {
    return this.http
      .request(method, url, options ?? this.options)
      .pipe(catchError((error) => this.errorHandling(error)));
  }

  public get<T>(url: string, options?: any): Observable<T> {
    return this.http
      .get<T>(url, options ?? this.options)
      .pipe(
        catchError((error) => this.errorHandling(error))
      ) as unknown as Observable<T>;
  }

  public post<T>(url: string, body: any, options?: any): Observable<T> {
    return this.http
      .post<T>(url, body, options ?? this.options)
      .pipe(
        catchError((error) => this.errorHandling(error))
      ) as unknown as Observable<T>;
  }

  public put<T>(url: string, body: any, options?: any): Observable<T> {
    return this.http
      .put<T>(url, body, options ?? this.options)
      .pipe(
        catchError((error) => this.errorHandling(error))
      ) as unknown as Observable<T>;
  }

  public delete<T>(url: string, options?: any): Observable<T> {
    return this.http
      .delete<T>(url, options ?? this.options)
      .pipe(
        catchError((error) => this.errorHandling(error))
      ) as unknown as Observable<T>;
  }

  errorHandling(error: HttpErrorResponse) {
    const errorMessage = error.error?.error?.message;
    if (/(4|5)\d\d/g.exec(String(error.status))) {
      if (error.status == 401) {
        this.notification.error(errorMessage ?? 'Failed', '');
        this.router.navigateByUrl('/sign-in');
      } else if (/4\d\d/g.exec(String(error.status))) {
        this.notification.error(
          // errorMessage ?? "Failed" , "Your request is not accepted" :
          'Failed',
          error.error.error.message
        );
      } else {
        this.notification.error('Failed', 'Server error');
      }
    } else {
      this.notification.error('Failed', 'Undocumented');
    }
    return throwError(error);
  }
}
