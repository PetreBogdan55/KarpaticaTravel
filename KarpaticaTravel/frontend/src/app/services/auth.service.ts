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

  clearToken() {
    localStorage.clear();
  }

  getToken() {
    return localStorage.getItem('token');
  }

  saveId(id: string) {
    localStorage.setItem('id', id);
  }

  saveIsOwner(isOwner: string) {
    localStorage.setItem('isOwner', isOwner);
  }

  getId() {
    return localStorage.getItem('id');
  }

  getIsOwner() {
    return localStorage.getItem('isOwner');
  }

  saveUsername(username: string) {
    localStorage.setItem('username', username);
  }

  getUsername() {
    return localStorage.getItem('username');
  }

  isAuthenticated() {
    if (this.getToken()) {
      return true;
    }
    return false;
  }
}
