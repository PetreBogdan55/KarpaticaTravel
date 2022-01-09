export interface Location {
  id: string;
  cityId: string;
  ownerId: string;
  activityId: string;
  name: string;
  address: string;
  distanceFromCenter: number;
  pricePerDay: number;
  isAvailable: boolean;
  photo: string;
  capacity: number;
}
