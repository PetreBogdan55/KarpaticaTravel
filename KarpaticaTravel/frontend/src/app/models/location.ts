export interface Location {
  _locationId: number
  _cityId: number
  _ownerId: number
  _activityId: number
  name: string
  address: string
  distanceFromUser: number
  pricePerDay: number
  isAvailable: boolean
}
