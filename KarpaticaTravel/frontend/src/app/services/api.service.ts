import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Country } from '../models/country';
import { Credentials } from '../models/credentials';
import { Location } from 'src/app/models/location';

import { User } from '../models/user';
import { Review } from '../models/review';
import { Booking } from '../models/booking';

import { map } from 'rxjs/operators';
import { Activity } from '../models/activity';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private http: HttpClient) {}

  createUser(user: User) {
    return this.http.post(`${environment.API_URL}/Users`, user);
  }

  deleteUser(userId: number) {
    return this.http.delete(`${environment.API_URL}/Users/` + userId);
  }

  editUser(userId: number, editedUser: User) {
    return this.http.put(`${environment.API_URL}/Users/` + userId, editedUser);
  }

  getUser(userId: string): Observable<User> {
    return this.http.get<User>(`${environment.API_URL}/Users/` + userId);
  }

  getUsers() {
    return this.http.get(`${environment.API_URL}/Users`);
  }

  getCountries() {
    return this.http.get(`${environment.API_URL}/Countries`);
  }

  getCities() {
    return this.http.get(`${environment.API_URL}/Cities`, {
      responseType: 'json',
    });
  }

  getCity(Id: string) {
    return this.http.get(`${environment.API_URL}/Cities/` + Id);
  }

  getActivities() {
    return this.http.get(`${environment.API_URL}/Activities`, {
      responseType: 'json',
    });
  }

  getLocations(): Observable<Location[]> {
    return this.http.get<Location[]>(`${environment.API_URL}/Locations`);
  }

  getLocation(Id: string) {
    return this.http.get(`${environment.API_URL}/Locations/` + Id);
  }

  getLocationsByActivity(activityID: string) {
    return this.http.get(
      `${environment.API_URL}/Locations/byActivity/` + activityID
    );
  }

  getLocationsByCity(cityId: string) {
    return this.http.get(`${environment.API_URL}/Locations/ByCity/` + cityId);
  }

  getReviewsByUser(Id: string): Observable<Review[]> {
    return this.http.get<Review[]>(`${environment.API_URL}/Reviews/` + Id);
  }

  getReviewsByLocation(Id: string): Observable<Review[]> {
    return this.http.get<Review[]>(
      `${environment.API_URL}/Reviews/Location/` + Id
    );
  }

  GetLocationsByCountryAndCity(
    CountryId: string,
    CityId: string
  ): Observable<Location[]> {
    return this.http.get<Location[]>(
      `${environment.API_URL}/Locations/ByCountryAndCity/` +
        CountryId +
        `/` +
        CityId
    );
  }

  getBookingsByUser(Id: string) {
    return this.http.get(`${environment.API_URL}/Bookings/Users/` + Id);
  }

  createBooking(booking: Booking) {
    return this.http.post(`${environment.API_URL}/Bookings`, booking, {
      responseType: 'text',
    });
  }

  deleteBooking(bookingId: string) {
    return this.http.delete(`${environment.API_URL}/Bookings/` + bookingId, {
      responseType: 'text',
    });
  }
  deleteLocation(locationId: string) {
    return this.http.delete(`${environment.API_URL}/Locations/` + locationId, {
      responseType: 'text',
    });
  }

  createLocation(location: Location) {
    return this.http.post(`${environment.API_URL}/Locations`, location, {
      responseType: 'text',
    });
  }
}
