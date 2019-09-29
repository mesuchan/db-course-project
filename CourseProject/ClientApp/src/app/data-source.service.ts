import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
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

  getAllProducts(): Observable<any[]> {
    return this.http.get <any[]>(this.base + 'products');
  }

  getProduct(id: string): Observable<any> {
    return this.http.get<any>(this.base + 'products/' + id);
  }

  getProfile(): Observable<any> {
    return this.http.get <any>(this.base + 'user', this.getOptions());
  }

  updateProfile(p: any): Observable<any> {
    console.log(p);
    return this.http.put <any>(this.base + 'user', p, this.getOptions());
  }

  private getOptions(): any {
    if (this.token == null)
      return {};

    return { headers: new HttpHeaders({ "Content-Type": "application/json", "Authorization": "Bearer " + this.token}) };
  }

  order(o: any): Observable<any> {
    return this.http.post <any>(this.base + 'products/purchase', o, this.getOptions());
  }

  view(id: number): Observable<any> {
    return this.http.post<any>(this.base + 'products/' + id.toString(), {}, this.getOptions());
  }

  recommended(): Observable<any> {
    return this.http.get<any>(this.base + 'products/recommended', this.getOptions());
  }

  deauth() {
    this.token = null;
  }
}
