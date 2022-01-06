export interface Location {
  id: string;
  cityId: number;
  ownerId: number;
  activityId: number;
  name: string;
  address: string;
  distanceFromCenter: number;
  pricePerDay: number;
  isAvailable: boolean;
  photo: string;
  capacity: number;
}
