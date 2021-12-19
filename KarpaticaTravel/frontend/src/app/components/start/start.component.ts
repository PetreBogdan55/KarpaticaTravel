import { Component, OnInit, ViewChild } from '@angular/core';
import { SidebarComponent } from '@syncfusion/ej2-angular-navigations';
import { countries } from './../../models/country';

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

  @ViewChild('sidebar') sidebar: SidebarComponent;
  public closeOnDocumentClick: boolean = true;
  public onCreated(args: any) {
    this.sidebar.hide();
    this.sidebar.element.style.visibility = '';
  }

  toggleClick(): void {
    this.sidebar.show();
  }

  constructor() {}

  ngOnInit(): void {}
}
