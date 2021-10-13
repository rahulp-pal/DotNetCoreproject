import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { ISignIn } from '../pages/signin/models/signin.model';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { ConfigurationService } from '../../../core/services/configuration/configuration.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  apiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    })
  };
  constructor(private http: HttpClient,
    private configurationService: ConfigurationService) {
    this.apiUrl = this.configurationService.apiUrl;
  }

  signin(signin: ISignIn): Observable<any> {
    return this.http.post<any>(this.apiUrl + 'api/account/login', signin, this.httpOptions)
      .pipe(
        map(res => res),
        catchError(this.error)
      );
  }

  error(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
