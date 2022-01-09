import { Country } from 'src/app/models/country';
import { ApiService } from '../services/api.service';
import { City } from './city';

export class Search {
  public countries: any = [];
  public cities: any = [];
  public packageTypes: string[] = ['Accommodation only', 'Resort', 'Circuit'];
  public numberOfNights: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
  public roomTypes: string[] = ['Single', 'Double', 'Triple', 'Apartament'];
  public numberOfRooms: number[] = [1, 2, 3, 4, 5];
  public adultsNumber: number[] = [1, 2, 3, 4, 5, 6];
  public kidsNumber: number[] = [0, 1, 2, 3, 4];

  constructor(private apiService: ApiService) {
    this.apiService
      .getCountries()
      .pipe()
      .subscribe((countries) => {
        let countriesName: string[] = [];
        this.countries = [];
        for (let country of countries as Country[])
          countriesName.push(country.name);
        this.countries = countriesName;
      });
    this.apiService
      .getCities()
      .pipe()
      .subscribe((cities) => {
        let citiesName: string[] = [];
        this.countries = [];
        for (let city of cities as City[]) citiesName.push(city.name);
        this.cities = citiesName;
      });
  }
}
