import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Country } from '../models/country';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private http: HttpClient) {}

  createUser(user: User) {
    return this.http.post(`${environment.API_URL}/Users`, user);
  }

  deleteUser(userId: number) {
    return this.http.delete(`${environment.API_URL}/Users`, {
      params: { Id: `${userId}` },
    });
  }

  editUser(userId: number, editedUser: User) {
    return this.http.put(`${environment.API_URL}/Users`, editedUser, {
      params: { Id: `${userId}` },
    });
  }

  getUser(userId: number) {
    return this.http.get(`${environment.API_URL}/Users`, {
      params: { Id: `${userId}` },
    });
  }

  getUsers() {
    return this.http.get(`${environment.API_URL}/Users`);
  }

  getCountries() {
    return this.http.get(`${environment.API_URL}/Countries`);
  }

  getCities() {
    return this.http.get(`${environment.API_URL}/Cities`);
  }

  getActivities() {
    return this.http.get(`${environment.API_URL}/Activities`);
  }

  getLocations() {
    return this.http.get(`${environment.API_URL}/Locations`);
  }
}
