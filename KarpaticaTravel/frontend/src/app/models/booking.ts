
export interface Booking {
  userId: number;
  locationId: number;
  id: number;
  checkInDate: Date;
  checkOutDate: Date;
  isCancellable: boolean;
}
