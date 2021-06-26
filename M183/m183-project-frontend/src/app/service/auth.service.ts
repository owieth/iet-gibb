import {Injectable} from '@angular/core';
import {JwtHelperService} from '@auth0/angular-jwt';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {User} from '../models/user';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  url = environment.backendUrl + 'auth';

  constructor(public jwtHelper: JwtHelperService, private http: HttpClient) {
  }

  get token(): string {
    return localStorage.getItem('access_token') || '';
  }

  setToken(token: string | null): void {
    if (typeof token === 'string') {
      localStorage.setItem('access_token', token);
    }
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('access_token');
    // @ts-ignore
    return !this.jwtHelper.isTokenExpired(token);
  }

  verify(): Observable<HttpResponse<string>> {
    return this.http.post<string>(this.url, {}, {observe: 'response', headers: {access_token: this.token}});
  }

  signUp(user: User): Observable<HttpResponse<string>> {
    return this.http.post<string>(this.url + '/signup', user, {observe: 'response'});
  }

  login(user: User): Observable<HttpResponse<string>> {
    return this.http.post<string>(this.url + '/login', user, {observe: 'response'});
  }
}
