import { Component, OnInit } from '@angular/core';
import { BookingService } from '../shared/services/booking.service';
import { Booking } from '../shared/models/booking.model';
import { Router, Route, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-booking-detail',
  templateUrl: './booking-detail.component.html',
  styleUrls: ['./booking-detail.component.scss']
})
export class BookingDetailComponent implements OnInit {

  booking: Booking = new Booking();
  disabledButton = false;
  today = new Date(Date.now());
  errorMessage: string;

  constructor(private bookingService: BookingService, private route: ActivatedRoute, private router: Router) {
    var id = +this.route.snapshot.paramMap.get('id');
    this.bookingService.getBookingById(id).subscribe(val => {
      this.booking = val
      this.booking.bookingTime = new Date(val.bookingTime);
      this.booking.bookingEndTime = new Date(val.bookingEndTime);
      console.log(this.booking);
      if(this.booking.bookingEndTime < this.today){
        this.disabledButton = true;
      }
    });
  }

  ngOnInit() {
  }

  checkIfFormCorrect() {
    let startDate = this.booking.bookingTime.getDate();
    let endDate = this.booking.bookingEndTime.getDate();
    let startHours = this.booking.bookingTime.getHours();
    let endHours = this.booking.bookingEndTime.getHours();
    let startMinutes = this.booking.bookingTime.getMinutes();
    let endMinutes = this.booking.bookingEndTime.getMinutes();

    if (this.booking.bookingTime < this.today) {
      console.log("Startdatum kleiner als heute");
      this.errorMessage = "Startdatum/Zeit ist kleiner als heute";
      this.disabledButton = true;
      return;
    }
    if (this.booking.bookingEndTime <= this.today) {
      console.log("Enddatum kleiner als heute");
      this.errorMessage = "Enddatum/Zeit ist kleiner als heute";
      this.disabledButton = true;
      return;
    }
    if(startDate === endDate){
      if (startHours > endHours || startHours === endHours) {
        if (startMinutes > endMinutes || startMinutes === endMinutes) {
          console.log("Startdatum grösser oder gleich als Enddatum");
          this.errorMessage = "Startdatum/Zeit grösser oder gleich als Enddatum/Zeit";
          this.disabledButton = true;
          return;
        }
      }
    }
    if (this.booking.room !== '' && this.booking.enumber !== '' && this.booking.bookingTime !== null && this.booking.bookingEndTime !== null) {
      console.log(this.booking);
      this.errorMessage = null;
      this.disabledButton = false;
    } else {
      this.disabledButton = true;
    }

  }

  updateBooking() {
    this.bookingService.updateBooking(this.booking).subscribe(val => {
      if (val.statusText === "OK") {
        this.router.navigate(["/bookings"]);
      } else {
        console.log("Didnt work");
      }
      console.log(this.booking)
    });
  }


}
