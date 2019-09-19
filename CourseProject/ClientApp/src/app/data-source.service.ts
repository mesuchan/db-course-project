import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataSourceService {
  base: string = 'https://localhost:5001/api/';
  token: string = null;
  constructor(private http: HttpClient) { }

  get isLogged(): boolean {
    return this.token != null;
  }

  register(login: string, password: string): Observable<any> {
    return this.http.post(this.base + 'auth/register', { login, password });
  }

  auth(login: string, password: string): Observable<boolean> {
    return this.http.post(this.base + 'auth', { login, password })
      .pipe(map(res => {
        this.token = res['accessToken'];
        return true;
      }), catchError(e => of(false)));
  }

  deauth() {
    this.token = null;
  }
}
