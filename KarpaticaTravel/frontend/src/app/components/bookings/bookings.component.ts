import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Booking } from 'src/app/models/booking';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.scss'],
})
export class BookingsComponent implements OnInit {
  public bookings: Booking[] = [];
  public username: string | null;
  private readonly unsubscribe$ = new Subject<void>();

  constructor(
    private authService: AuthService,
    private apiService: ApiService
  ) {}

  ngOnInit(): void {
    const id = this.authService.getId();
    if (id) {
      this.username = this.authService.getUsername();
      this.apiService
        .getBookingsByUser(id)
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe((bookings) => {
          this.bookings = bookings as Booking[];
          console.log(this.bookings);
          // for (let review of this.reviews) {
          //   this.apiService
          //     .getLocation(review.locationId.toString())
          //     .pipe(takeUntil(this.unsubscribe$))
          //     .subscribe((location) => {
          //       this.locations.push(location as unknown as Location);
          //     });
          // }
        });
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
