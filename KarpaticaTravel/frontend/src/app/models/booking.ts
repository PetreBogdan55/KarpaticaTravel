import { Moment } from 'moment'

export interface Booking {
  _userId: number
  _locationId: number
  _bookingId: number
  checkInDate: Moment
  checkOutDate: Moment
}
