import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SearchService } from 'src/app/services/search.service';
import { Location } from 'src/app/models/location';
import * as moment from 'moment';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss'],
})
export class ResultsComponent implements OnInit {
  public locations: Location[] = [
    {
      _locationId: 1,
      _cityId: 1,
      _ownerId: 1,
      _activityId: 1,
      name: 'Red Roof Inn Asheville West',
      address: 'Asheville (NC), United States',
      distanceFromCityCenter: 120.43,
      pricePerDay: 12,
      package: 'Resort',
      isAvailable: true,
      rooms: 6,
      checkInDate: new Date('2021-12-25')
        .toISOString()
        .split('T')[0]
        .toString(),
      checkOutDate: new Date('2021-12-27')
        .toISOString()
        .split('T')[0]
        .toString(),
      photo:
        'https://i.travelapi.com/hotels/1000000/30000/22800/22774/9064b9f7.jpg',
    },
    {
      _locationId: 1,
      _cityId: 1,
      _ownerId: 1,
      _activityId: 1,
      name: 'Holiday Inn Asheville-airport (i-26)',
      address: 'Asheville (NC), United States',
      distanceFromCityCenter: 120.43,
      pricePerDay: 112,
      package: 'Circuit',
      isAvailable: false,
      rooms: 0,
      checkInDate: new Date('2021-12-24')
        .toISOString()
        .split('T')[0]
        .toString(),
      checkOutDate: new Date('2021-12-30')
        .toISOString()
        .split('T')[0]
        .toString(),
      photo:
        'https://i.travelapi.com/hotels/1000000/20000/16600/16564/7bca8ddc.jpg',
    },
  ];
  constructor(
    private _router: Router,
    public searchService: SearchService,
    private toastr: ToastrService //private apiService: ApiService
  ) {
    console.log(this.searchService.searchFiltersObject);
  }

  ngOnInit(): void {}
}
