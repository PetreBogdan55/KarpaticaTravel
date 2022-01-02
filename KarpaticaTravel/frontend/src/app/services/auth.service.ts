import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Credentials } from '../models/credentials';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  loginUser(credentials: Credentials): Observable<any> {
    return this.http.post(`${environment.API_URL}/Users/Login`, credentials);
  }

  createUser(user: User) {
    return this.http.post(`${environment.API_URL}/Users`, user);
  }

  saveToken(token: string) {
    localStorage.setItem('token', token);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  saveId(id: string) {
    localStorage.setItem('id', id);
  }

  getId() {
    return localStorage.getItem('id');
  }

  saveName(name: string) {
    localStorage.setItem('name', name);
  }

  getName() {
    return localStorage.getItem('name');
  }

  isAuthenticated() {
    if (this.getToken()) {
      return true;
    }
    return false;
  }
}