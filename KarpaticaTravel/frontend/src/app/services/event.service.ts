import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EventService {
  private loginEvent$ = new BehaviorSubject<string>('');

  emitUsername(username: string) {
    this.loginEvent$.next(username);
  }

  loginEventListener(): Observable<string> {
    return this.loginEvent$.asObservable();
  }

  constructor() {}
}
