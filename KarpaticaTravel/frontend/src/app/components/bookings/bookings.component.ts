import { Location } from 'src/app/models/location';
import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Booking } from 'src/app/models/booking';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.scss'],
})
export class BookingsComponent implements OnInit {
  public bookings: Booking[] = [];
  public locations: Location[] = [];
  public username: string | null;
  private readonly unsubscribe$ = new Subject<void>();

  constructor(
    private authService: AuthService,
    private apiService: ApiService,
    private toastr: ToastrService
  ) {}

  getBookings() {
    const id = this.authService.getId();
    if (id) {
      this.username = this.authService.getUsername();
      this.apiService
        .getBookingsByUser(id)
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe((bookings) => {
          this.bookings = bookings as Booking[];
          for (let booking of this.bookings) {
            this.apiService
              .getLocation(booking.locationId)
              .pipe(takeUntil(this.unsubscribe$))
              .subscribe((location) => {
                this.locations.push(location as Location);
              });
          }
        });
    }
  }

  ngOnInit(): void {
    this.getBookings();
  }

  removeBooking(booking: Booking) {
    this.apiService
      .deleteBooking(booking.id)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(() => {
        this.getBookings();
        this.toastr.success(
          'Booking deleted successfully!',
          'Booking deletion status'
        );
      });
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
