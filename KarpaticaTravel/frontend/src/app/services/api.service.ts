import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private http: HttpClient) {}

  createUser(user: User) {
    return this.http.post(`${environment.API_URL}/users`, user);
  }

  deleteUser(userId: number) {
    return this.http.delete(`${environment.API_URL}/users`, {
      params: { Id: `${userId}` },
    });
  }

  editUser(userId: number, editedUser: User) {
    return this.http.put(`${environment.API_URL}/users`, editedUser, {
      params: { Id: `${userId}` },
    });
  }

  getUser(userId: number) {
    return this.http.get(`${environment.API_URL}/users`, {
      params: { Id: `${userId}` },
    });
  }

  getUsers() {
    return this.http.get(`${environment.API_URL}/users`);
  }
}
