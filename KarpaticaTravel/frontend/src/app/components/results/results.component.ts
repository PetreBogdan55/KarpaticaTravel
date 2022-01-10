import { City } from './../../models/city';
import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SearchService } from 'src/app/services/search.service';
import { Location } from 'src/app/models/location';
import { MatSliderChange } from '@angular/material/slider';
import { ApiService } from 'src/app/services/api.service';
import { Observable, Subject, Subscription } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { MatTreeFlatDataSource } from '@angular/material/tree';
import { CountryCode } from 'ngx-mat-intl-tel-input/lib/data/country-code';
import { Country } from 'src/app/models/country';

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
  public locationsByActivity: Location[] = [];
  public locationsByCity: Location[] = [];
  public isFilteredLocationsActivity: boolean = false;
  public isFilteredLocationsCity: boolean = false;
  public isFinalLocations: boolean = true;
  private readonly unsubscribe$ = new Subject<void>();
  public countries: Country[] = [];
  public cities: City[] = [];

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
      .getCountries()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((countries) => {
        this.countries = countries as Country[];
      });

    this.apiService
      .getCities()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((cities) => {
        this.cities = cities as City[];
      });

    if (localStorage.getItem('locFilteredActivity') != null) {
      this.isFinalLocations = false;
      this.apiService
        .getLocationsByActivity(
          <string>localStorage.getItem('locFilteredActivity')
        )
        .subscribe((res) => {
          this.locationsByActivity = <Location[]>res;
          this.isFilteredLocationsActivity = true;
        });
    }

    if (localStorage.getItem('locFilteredCity') != null) {
      this.isFinalLocations = false;
      this.apiService
        .getLocationsByCity(<string>localStorage.getItem('locFilteredCity'))
        .subscribe((res) => {
          this.locationsByCity = <Location[]>res;
          this.isFilteredLocationsCity = true;
        });
    }

    if (this.isFinalLocations) {
      this.apiService
        .getLocations()
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe((locations) => {
          this.locations = locations;
          this.findLocationsThatMatch();
        });
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
    localStorage.removeItem('locFilteredActivity');
    localStorage.removeItem('locFilteredCity');
  }

  onDistanceChange(event: MatSliderChange) {
    if (event.value) {
      this.distanceSliderValue = event.value;
    }
  }

  onPriceChange(event: MatSliderChange) {
    if (event.value) {
      this.priceSliderValue = event.value;
    }
  }

  // lolFindLocationssThatMatch(): void {
  //   this.finalLocations = [];
  //   for (let location of this.locations) {
  //     if (
  //       location.distanceFromCenter <= this.distanceSliderValue &&
  //       location.pricePerDay <= this.priceSliderValue
  //     )
  //       for (let country of this.countries) {
  //         if (
  //           country.name == this.searchService.searchFiltersObject.chosenCountry
  //         ) {
  //           this.apiService
  //             .GetLocationsByCountryAndCity(
  //               country.id,
  //               location.cityId.toString()
  //             )
  //             .pipe(takeUntil(this.unsubscribe$))
  //             .subscribe((next: Location[]) => {
  //               for (let n of next) {
  //                 if (n.name == location.name) {
  //                   this.finalLocations.push(n);
  //                 }
  //               }
  //             });
  //         }
  //       }
  //   }
  // }

  findLocationsThatMatch(): void {
    const chosenCountryId: string = this.getIdFromCountry(
      this.searchService.searchFiltersObject.chosenCountry
    );

    const chosenCityd: string = this.getIdFromCity(
      this.searchService.searchFiltersObject.chosenCity
    );

    this.apiService
      .GetLocationsByCountryAndCity(chosenCountryId, chosenCityd)
      .subscribe((res) => {
        this.finalLocations = res;
      });
  }

  getIdFromCity(cityName: string): any {
    return this.cities.find((city) => city.name === cityName)?.id;
  }

  getIdFromCountry(countryName: string): any {
    return this.countries.find((country) => country.name === countryName)?.id;
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
