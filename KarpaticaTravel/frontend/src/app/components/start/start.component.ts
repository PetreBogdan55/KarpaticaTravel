import { Component, OnInit, ViewChild } from '@angular/core';
import { countries } from './../../models/country';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.scss'],
})
export class StartComponent implements OnInit {
  public chosenPackage: string = 'Choose package type';
  public chosenCountry: string = 'Select Country';
  public chosenCity: string = 'Select City';
  public chosenDate: string = '2018-07-22';
  public chosenNumberOfNights: number = 1;

  public countries: any = countries;
  public cities: any = countries;
  public packageTypes: string[] = ['Accommodation only', 'Resort', 'Circuit'];
  public numberOfNights: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
  public roomTypes: string[] = ['Single', 'Double', 'Triple', 'Apartament'];
  public numberOfRooms: number[] = [1, 2, 3, 4, 5];
  public adultsNumber: number[] = [1, 2, 3, 4, 5, 6];
  public kidsNumber: number[] = [0, 1, 2, 3, 4];

  constructor(private _router: Router, private toastr: ToastrService) {}

  ngOnInit(): void {}

  onSearch(): void {
    if (this.chosenPackage === 'Choose package type') {
      this.toastr.error('Please choose a package type!', 'Missing fields!');
      return;
    }
    if (this.chosenCountry === 'Select Country') {
      this.toastr.error('Please choose a country!', 'Missing fields!');
      return;
    }
    if (this.chosenCity === 'Select City') {
      this.toastr.error('Please choose a city!', 'Missing fields!');
      return;
    }
    this.toastr.success('Hello world!', 'Toastr fun!');
    this._router.navigate(['results']);
  }
}
