import { ApiService } from 'src/app/services/api.service';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Review } from 'src/app/models/review';
import { Location } from 'src/app/models/location';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss'],
})
export class ReviewsComponent implements OnInit {
  private readonly unsubscribe$ = new Subject<void>();
  public reviews: Review[] = [];
  public locations: Location[] = [];
  public username: string | null;

  constructor(
    private authService: AuthService,
    private apiService: ApiService
  ) {}

  ngOnInit(): void {
    const id = this.authService.getId();
    if (id) {
      this.username = this.authService.getUsername();
      this.apiService
        .getReviewsByUser(id)
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe((reviews) => {
          this.reviews = reviews as Review[];
          for (let review of reviews) {
            this.apiService
              .getLocation(review.locationId.toString())
              .pipe(takeUntil(this.unsubscribe$))
              .subscribe((location) => {
                this.locations.push(location as unknown as Location);
              });
          }
        });
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
