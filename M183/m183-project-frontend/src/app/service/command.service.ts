import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {Observable} from 'rxjs';
import {HttpClient, HttpParams} from '@angular/common/http';
import {AuthService} from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class CommandService {

  url = environment.backendUrl + 'command';

  constructor(private http: HttpClient, private authService: AuthService) { }

  getAllCommands(): Observable<string[]> {
    return this.http.get<string[]>(this.url + '/list', {
      headers: {access_token: this.authService.token}
    });
  }

  executeCommand(command: string): Observable<string> {
    return this.http.get<string>(this.url, {
      params: new HttpParams().set('command', command),
      headers: {access_token: this.authService.token}
    });
  }
}
