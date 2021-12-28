import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SearchService } from 'src/app/services/search.service';
import { Location } from 'src/app/models/location';
import { MatSliderChange } from '@angular/material/slider';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss'],
})
export class ResultsComponent implements OnInit {
  distanceSliderValue: number;
  priceSliderValue: number;
  public finalLocations: Location[] = [];
  public locations: Location[] = [
    {
      _locationId: 1,
      _cityId: 1,
      _ownerId: 1,
      _activityId: 1,
      name: 'Red Roof Inn Asheville West',
      address: 'Asheville (NC), United States',
      distanceFromCityCenter: 120.43,
      pricePerDay: 612,
      package: 'Resort',
      isAvailable: true,
      rooms: 5,
      checkInDate: new Date('2021-12-28')
        .toISOString()
        .split('T')[0]
        .toString(),
      checkOutDate: new Date('2021-12-30')
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
      distanceFromCityCenter: 80.89,
      pricePerDay: 400,
      package: 'Resort',
      isAvailable: false,
      rooms: 5,
      checkInDate: new Date('2021-12-28')
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
    this.distanceSliderValue = 200;
    this.priceSliderValue = 2000;
    this.findLocationsThatMatch();
    console.log(this.searchService.searchFiltersObject);
  }

  ngOnInit(): void {}

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
        location.package ==
          this.searchService.searchFiltersObject.chosenPackage &&
        location.rooms ==
          this.searchService.searchFiltersObject.chosenNumberOfRooms &&
        location.checkInDate ==
          this.searchService.searchFiltersObject.chosenDate &&
        location.address.includes(
          this.searchService.searchFiltersObject.chosenCity
        ) &&
        location.address.includes(
          this.searchService.searchFiltersObject.chosenCountry
        ) &&
        (new Date(location.checkOutDate).getTime() -
          new Date(location.checkInDate).getTime()) /
          (1000 * 60 * 60 * 24) ==
          this.searchService.searchFiltersObject.chosenNumberOfNights &&
        location.distanceFromCityCenter <= this.distanceSliderValue &&
        location.pricePerDay <= this.priceSliderValue
      )
        this.finalLocations.push(location);
    }
  }
}
