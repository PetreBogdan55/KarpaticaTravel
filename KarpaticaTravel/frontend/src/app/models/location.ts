export interface Location {
  _locationId: number;
  _cityId: number;
  _ownerId: number;
  _activityId: number;
  name: string;
  address: string;
  distanceFromCityCenter: number;
  pricePerDay: number;
  isAvailable: boolean;
  rooms: number;
  checkInDate: string;
  checkOutDate: string;
  photo: string;
  package: string;
}
