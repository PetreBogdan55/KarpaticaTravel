import { SearchService } from './../../services/search.service';
import { SearchFilters } from './../../models/searchFilters';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router, Scroll } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { Search } from 'src/app/models/search';
import { Image } from 'src/app/models/image';
import { filter } from 'rxjs/operators';
import { ViewportScroller } from '@angular/common';
import { Activity } from 'src/app/models/activity';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.scss'],
})
export class StartComponent implements OnInit {
  images: Array<Image> = new Array<Image>();
  activities: Activity[] = [];

  public minSearchDate: string;
  public maxSearchDate: string;

  public searchObject: Search;

  constructor(
    private _router: Router,
    public searchService: SearchService,
    private viewportScroller: ViewportScroller,
    private toastr: ToastrService,
    private apiService: ApiService
  ) {
    this.searchObject = new Search(this.apiService);
    let date = new Date();
    let maxDate = new Date();
    this.searchService.searchFiltersObject.chosenDate = date
      .toISOString()
      .split('T')[0]
      .toString();
    this.minSearchDate = this.searchService.searchFiltersObject.chosenDate;
    maxDate.setDate(date.getDate() + 3);
    this.maxSearchDate = maxDate.toISOString().split('T')[0].toString();
  }

  ngOnInit(): void {
    /*
    for (let i = 0; i < 10; ++i) {
      const image: Image = {
        src: './Full HD Desktop Wallpapers 1920×1080 (42 Wallpapers) – Adorable Wallpapers.jpg',
      };
      this.images.push(image);
    }
    */
    //this.countries = this.apiService.getCountries();
    //this.cities = this.apiService.getCities();

    this.apiService.getActivities().subscribe((res) => {
      this.activities = <Activity[]>res;
    });
  }

  onSearch(): void {
    if (
      this.searchService.searchFiltersObject.chosenPackage ===
      'Choose package type'
    ) {
      this.toastr.error('Please choose a package type!', 'Missing fields!');
      return;
    }
    if (
      this.searchService.searchFiltersObject.chosenCountry === 'Select Country'
    ) {
      this.toastr.error('Please choose a country!', 'Missing fields!');
      return;
    }
    if (this.searchService.searchFiltersObject.chosenCity === 'Select City') {
      this.toastr.error('Please choose a city!', 'Missing fields!');
      return;
    }
    this._router.navigate(['results']);
  }

  getLocationsByActivity(activitiyId: string): void {
    localStorage.setItem('locFilteredActivity', activitiyId);
  }
}
