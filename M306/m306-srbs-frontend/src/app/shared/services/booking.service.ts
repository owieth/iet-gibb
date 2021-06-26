import {Injectable} from '@angular/core';
import {environment} from 'src/environments/environment';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Booking} from '../models/booking.model';

@Injectable({
  providedIn: 'root'
})

//Service with all Methods to get, create and update Bookings || Author: Domenico Winkelmann
export class BookingService {

  private bookingUrl: string = environment.backendUrl + "bookings";
  sortedName = false;

  constructor(private http: HttpClient) {
  }

  getAllBookings(): Observable<Booking[]> {
    return this.http.get<Booking[]>(this.bookingUrl);
  }

  getBookingById(id: number): Observable<Booking> {
    return this.http.get<Booking>(this.bookingUrl + "/" + id);
  }

  createBooking(booking: Booking): Observable<HttpResponse<Booking>>{
    return this.http.post<Booking>(this.bookingUrl + "/create", booking, { observe: 'response' });
  }

  updateBooking(booking: Booking): Observable<HttpResponse<Booking>>{
    return this.http.put<Booking>(this.bookingUrl + "/" + booking.id, booking, { observe: 'response' });
  }

  deleteBooking(id: number): Observable<Booking>{
    return this.http.delete<Booking>(this.bookingUrl + "/" + id);
  }

  filterBookingsByRoom(bookings: Booking[]): any {
    if (!this.sortedName) {
      this.sortedName = true;
      const sortFunction = (a, b) => {
        if (a.room.toLowerCase() < b.room.toLowerCase()) { return -1; }
        if (a.room.toLowerCase() > b.room.toLowerCase()) { return 1; }
        return 0;
      };
      bookings.sort(sortFunction);
    } else {
      this.sortedName = false;
      const sortFunction = (a, b) => {
        if (a.room.toLowerCase() > b.room.toLowerCase()) { return -1; }
        if (a.room.toLowerCase() < b.room.toLowerCase()) { return 1; }
        return 0;
      };
      bookings.sort(sortFunction);
    }
  }

  filterBookingsByStart(bookings: Booking[]): any {
    if (!this.sortedName) {
      this.sortedName = true;
      const sortFunction = (a, b) => {
        if (a.bookingTime.toLowerCase() < b.bookingTime.toLowerCase()) { return -1; }
        if (a.bookingTime.toLowerCase() > b.bookingTime.toLowerCase()) { return 1; }
        return 0;
      };
      bookings.sort(sortFunction);
    } else {
      this.sortedName = false;
      const sortFunction = (a, b) => {
        if (a.bookingTime.toLowerCase() > b.bookingTime.toLowerCase()) { return -1; }
        if (a.bookingTime.toLowerCase() < b.bookingTime.toLowerCase()) { return 1; }
        return 0;
      };
      bookings.sort(sortFunction);
    }
  }

  filterBookingsByFinish(bookings: Booking[]): any {
    if (!this.sortedName) {
      this.sortedName = true;
      const sortFunction = (a, b) => {
        if (a.bookingEndTime.toLowerCase() < b.bookingEndTime.toLowerCase()) { return -1; }
        if (a.bookingEndTime.toLowerCase() > b.bookingEndTime.toLowerCase()) { return 1; }
        return 0;
      };
      bookings.sort(sortFunction);
    } else {
      this.sortedName = false;
      const sortFunction = (a, b) => {
        if (a.bookingEndTime.toLowerCase() > b.bookingEndTime.toLowerCase()) { return -1; }
        if (a.bookingEndTime.toLowerCase() < b.bookingEndTime.toLowerCase()) { return 1; }
        return 0;
      };
      bookings.sort(sortFunction);
    }
  }

  filterBookingsByEnumber(bookings: Booking[]): any {
    if (!this.sortedName) {
      this.sortedName = true;
      const sortFunction = (a, b) => {
        if (a.enumber.toLowerCase() < b.enumber.toLowerCase()) { return -1; }
        if (a.enumber.toLowerCase() > b.enumber.toLowerCase()) { return 1; }
        return 0;
      };
      bookings.sort(sortFunction);
    } else {
      this.sortedName = false;
      const sortFunction = (a, b) => {
        if (a.enumber.toLowerCase() > b.enumber.toLowerCase()) { return -1; }
        if (a.enumber.toLowerCase() < b.enumber.toLowerCase()) { return 1; }
        return 0;
      };
      bookings.sort(sortFunction);
    }
  }

}
