import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Permiso } from 'src/app/models/permiso';

@Injectable({
  providedIn: 'root'
})
export class PermisosService {

  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/Permisos/';
  }

  getPermisos(): Observable<Permiso[]> {
    return this.http.get<Permiso[]>(this.myAppUrl + this.myApiUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getPermiso(id: number): Observable<Permiso> {
    return this.http.get<Permiso>(this.myAppUrl + this.myApiUrl + id)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  savePermiso(permiso): Observable<Permiso> {
    return this.http.post<Permiso>(this.myAppUrl + this.myApiUrl, permiso, this.httpOptions)
    .pipe(
      retry(0),
      catchError(this.errorHandler)
    );
  }

  deletePermiso(id): Observable<Permiso> {
    const params = new HttpParams().set('id', id);
    return this.http.delete<Permiso>(this.myAppUrl + this.myApiUrl, {params})
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  errorHandler(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error;
    } else {
      // Get server-side error
      errorMessage = `${error.error}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
