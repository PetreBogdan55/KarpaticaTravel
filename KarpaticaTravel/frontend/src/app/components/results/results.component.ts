import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SearchService } from 'src/app/services/search.service';
import { Location } from 'src/app/models/location';
import { MatSliderChange } from '@angular/material/slider';
import { ApiService } from 'src/app/services/api.service';
import { Observable, Subject, Subscription } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss'],
})
export class ResultsComponent implements OnInit, OnDestroy {
  distanceSliderValue: number;
  priceSliderValue: number;
  public finalLocations: Location[] = [];
  public locations: Location[] = [];
  private readonly unsubscribe$ = new Subject<void>();

  constructor(
    private _router: Router,
    public searchService: SearchService,
    private toastr: ToastrService,
    private apiService: ApiService
  ) {
    this.distanceSliderValue = 200;
    this.priceSliderValue = 2000;
  }

  ngOnInit(): void {
    this.apiService
      .getLocations()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((locations) => {
        this.locations = locations;
        this.findLocationsThatMatch();
      });
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  onDistanceChange(event: MatSliderChange) {
    if (event.value) {
      this.distanceSliderValue = event.value;
      this.findLocationsThatMatch();
    }
  }

  onPriceChange(event: MatSliderChange) {
    if (event.value) {
      this.priceSliderValue = event.value;
      this.findLocationsThatMatch();
    }
  }

  findLocationsThatMatch(): void {
    this.finalLocations = [];
    for (let location of this.locations) {
      if (
        location.distanceFromCenter <= this.distanceSliderValue &&
        location.pricePerDay <= this.priceSliderValue
      )
        this.finalLocations.push(location);
    }
  }

  onSortByAscendingPrice() {
    this.finalLocations = this.finalLocations.sort(
      (l1: Location, l2: Location) => {
        if (l1.pricePerDay > l2.pricePerDay) return 1;
        if (l1.pricePerDay < l2.pricePerDay) return -1;
        return 0;
      }
    );
  }

  onSortByDescendingPrice() {
    this.finalLocations = this.finalLocations.sort(
      (l1: Location, l2: Location) => {
        if (l1.pricePerDay > l2.pricePerDay) return -1;
        if (l1.pricePerDay < l2.pricePerDay) return 1;
        return 0;
      }
    );
  }

  onSortByAscendingDistance() {
    this.finalLocations = this.finalLocations.sort(
      (l1: Location, l2: Location) => {
        if (l1.distanceFromCenter > l2.distanceFromCenter) return 1;
        if (l1.distanceFromCenter < l2.distanceFromCenter) return -1;
        return 0;
      }
    );
  }

  onSortByDescendingDistance() {
    this.finalLocations = this.finalLocations.sort(
      (l1: Location, l2: Location) => {
        if (l1.distanceFromCenter > l2.distanceFromCenter) return -1;
        if (l1.distanceFromCenter < l2.distanceFromCenter) return 1;
        return 0;
      }
    );
  }
}
