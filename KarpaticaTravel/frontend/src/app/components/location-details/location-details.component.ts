import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Review } from 'src/app/models/review';
import { Location } from 'src/app/models/location';
import { ApiService } from 'src/app/services/api.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { NgxStarsComponent } from 'ngx-stars';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmBookingComponent } from '../confirm-booking/confirm-booking.component';

@Component({
  selector: 'app-location-details',
  templateUrl: './location-details.component.html',
  styleUrls: ['./location-details.component.scss'],
})
export class LocationDetailsComponent implements OnInit, OnDestroy {
  public reviews: Review[];
  public location: Location;
  public averageRating: number = 0;
  @ViewChild('cardStars') cardStars: NgxStarsComponent;
  private readonly unsubscribe$ = new Subject<void>();

  constructor(
    private apiService: ApiService,
    private activatedRoute: ActivatedRoute,
    private dialog: MatDialog
  ) {}

  ngOnDestroy(): void {
    this.unsubscribe$.complete();
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      let apiLocation = this.apiService.getLocation(params['id']);
      apiLocation.pipe(takeUntil(this.unsubscribe$)).subscribe((next: any) => {
        this.location = next as Location;
        this.loadReviews();
      });
    });
  }

  book() {
    this.dialog.open(ConfirmBookingComponent, {
      width: '1000px',
      height: '600px',
      autoFocus: true,
      disableClose: true,
      data: { locationId: this.location.id },
    });
  }

  loadReviews() {
    this.apiService
      .getReviewsByLocation(this.location.id)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((next) => {
        this.reviews = next as Review[];
        this.reviews.forEach((review) => {
          this.averageRating += review.rating;
          this.apiService.getUser(review.userId).subscribe((user) => {
            review.author = user.username;
          });
        });

        this.averageRating /= this.reviews.length;
        this.cardStars.setRating(this.averageRating);
      });
  }
}
