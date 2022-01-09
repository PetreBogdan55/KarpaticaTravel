import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ApiService } from 'src/app/services/api.service';
import { Location } from 'src/app/models/location';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SearchService } from 'src/app/services/search.service';
import { MatSliderChange } from '@angular/material/slider';
import { Country } from 'src/app/models/country';
import { AuthService } from 'src/app/services/auth.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AddLocationComponent } from '../add-location/add-location.component';
@Component({
  selector: 'app-administrator',
  templateUrl: './administrator.component.html',
  styleUrls: ['./administrator.component.scss'],
})
export class AdministratorComponent implements OnInit, OnDestroy {
  distanceSliderValue: number;
  priceSliderValue: number;
  public finalLocations: Location[] = [];
  public locations: Location[] = [];
  public locationsByActivity: Location[] = [];
  public isFilteredLocationsActivity: boolean = false;
  private readonly unsubscribe$ = new Subject<void>();
  public countries: Country[] = [];
  public form: FormGroup;

  constructor(
    private _router: Router,
    public searchService: SearchService,
    private toastr: ToastrService,
    private apiService: ApiService,
    public authService: AuthService,
    private formBuilder: FormBuilder,
    private dialog: MatDialog
  ) {
    this.distanceSliderValue = 200;
    this.priceSliderValue = 2000;
  }

  inputChange() {
    if (this.form.value.searchWord == '') {
      this.finalLocations = [...this.locations];
    } else {
      this.filterLocations();
    }
  }

  filterLocations() {
    this.finalLocations.length = 0;
    this.locations.forEach((location) => {
      if (
        location.name
          .toLowerCase()
          .includes((this.form.value.searchWord as string).toLowerCase())
      ) {
        this.finalLocations.push(location);
      }
    });
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      searchWord: '',
    });
    this.loadLocations();
  }

  loadLocations() {
    this.apiService
      .getLocations()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((locations) => {
        console.log(locations);
        this.locations = locations;
        this.finalLocations = [...locations];
      });

    if (localStorage.getItem('locFilteredActivity') != null) {
      this.apiService
        .getLocationsByActivity(
          <string>localStorage.getItem('locFilteredActivity')
        )
        .subscribe((res) => {
          this.locationsByActivity = <Location[]>res;
          this.isFilteredLocationsActivity = true;
        });
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
    localStorage.removeItem('locFilteredActivity');
  }

  findLocationsThatMatch(): void {
    this.finalLocations = this.locations;
  }

  deleteLocation(locationId: string) {
    this.apiService.deleteLocation(locationId).subscribe((next) => {
      console.log(next);
      this.loadLocations();
    });
  }

  addLocation() {
    this.dialog
      .open(AddLocationComponent, {
        width: '1000px',
        height: '600px',
        autoFocus: true,
        disableClose: false,
      })
      .afterClosed()
      .subscribe((data: Location) => {
        this.locations.push(data);
        this.finalLocations.push(data);
      });
  }
}
