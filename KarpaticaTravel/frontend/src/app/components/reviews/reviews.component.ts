import { ApiService } from 'src/app/services/api.service';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Review } from 'src/app/models/review';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss'],
})
export class ReviewsComponent implements OnInit {
  private readonly unsubscribe$ = new Subject<void>();
  public reviews: Review[] = [];

  constructor(
    private authService: AuthService,
    private apiService: ApiService
  ) {}

  ngOnInit(): void {
    const id = this.authService.getId();
    if (id) {
      this.apiService
        .getReviewsByUser(id)
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe((reviews) => {
          this.reviews = reviews as Review[];
          console.log(this.reviews);
        });
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
