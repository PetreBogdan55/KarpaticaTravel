export interface Booking {
  userId: string;
  locationId: string;
  id: string;
  checkInDate: Date;
  checkOutDate: Date;
  isCancellable: boolean;
}
