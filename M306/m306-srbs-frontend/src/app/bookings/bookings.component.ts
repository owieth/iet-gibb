import { Component, OnInit } from '@angular/core';
import { Booking } from '../shared/models/booking.model';
import {BookingService} from '../shared/services/booking.service';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.scss']
})
export class BookingsComponent implements OnInit {

  bookings: Booking[] = [];
  displayFullSize = false;
  bookingId: number;
  filteredBookings: Booking[] = [];

  constructor(private bookingService: BookingService) {  }

  ngOnInit() {
    this.getBookings();
  }

  //get array with all bookings || Author: Domenico Winkelmann
  getBookings(){
    this.bookingService.getAllBookings().subscribe(val => {
      this.bookings = val
      console.log(this.bookings);      
    });
  }

//delete booking by id and close lightbox || Author: Domenico Winkelmann
  deleteBooking(){
    this.bookingService.deleteBooking(this.bookingId).subscribe(val => {
      this.getBookings();
      this.closeModal();
    });
  }

  //open lightbox of booking-detail with id || Author: Domenico Winkelmann
  openModal(id: number){
    this.bookingId = id;
    this.displayFullSize = true;
  }

  //close Lightbox of booking-detail || Author: Domenico Winkelmann
  closeModal(){
    this.displayFullSize = false;
  }

  //All filters || Author: Domenico Winkelmann
  filterBookingRoom() {
    this.filteredBookings = [];
    let result;
    result = this.bookingService.filterBookingsByRoom(this.bookings);
    this.filteredBookings = result;
  }
  filterBookingStart() {
    this.filteredBookings = [];
    let result;
    result = this.bookingService.filterBookingsByStart(this.bookings);
    this.filteredBookings = result;
  }
  filterBookingFinish() {
    this.filteredBookings = [];
    let result;
    result = this.bookingService.filterBookingsByFinish(this.bookings);
    this.filteredBookings = result;
  }
  filterBookingEnumber() {
    this.filteredBookings = [];
    let result;
    result = this.bookingService.filterBookingsByEnumber(this.bookings);
    this.filteredBookings = result;
  }

}
