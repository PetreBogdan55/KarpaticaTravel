import { Activity } from './../../models/activity'
import { Component, OnInit } from '@angular/core'
import { ApiService } from 'src/app/services/api.service'

@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.scss'],
})
export class StartComponent implements OnInit {
  public countries: any
  public cities: any
  public packageTypes: string[] = ['Accommodation only', 'Resort', 'Circuit']
  public numberOfNights: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
  public roomTypes: string[] = ['Single', 'Double', 'Triple', 'Apartament']
  public numberOfRooms: number[] = [1, 2, 3, 4, 5]
  public adultsNumber: number[] = [1, 2, 3, 4, 5, 6]
  public kidsNumber: number[] = [0, 1, 2, 3, 4]

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.countries = this.apiService.getCountries()
    this.cities = this.apiService.getCities()
  }
}
