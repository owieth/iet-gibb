import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { BookingService } from '../shared/services/booking.service';
import { Booking } from '../shared/models/booking.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking-create',
  templateUrl: './booking-create.component.html',
  styleUrls: ['./booking-create.component.scss']
})

export class BookingCreateComponent implements OnInit {

  regex = new RegExp("^(u|U)([0-9]{6})\$|^(ue|UE|Ue)([0-9]{5})\$|^(e|E)([0-9]{6})\$");
  booking = new Booking();
  displayFullSize = false;
  disabledButton = true;
  today = new Date(Date.now());
  errorMessage: string;

  constructor(private bookingService: BookingService, private router: Router) {
    this.booking.room = '';
    this.booking.bookingTime = this.today;
    this.booking.bookingEndTime = null;
    this.booking.enumber = '';
  }

  ngOnInit() {

  }


  //Method for creating a new Booking || Author: Domenico Winkelmann
  createBooking() {
    this.bookingService.createBooking(this.booking).subscribe(val => {
      if (val.statusText === "OK") {
        this.router.navigate(["/bookings"]);
      } else {
        console.log("Didnt work");
      }
      console.log(this.booking)
    });
  }

  //Check if the dates match the creteria || Author: Domenico Winkelmann
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
    

    if (!this.regex.test(this.booking.enumber)) {
      console.log("regex");
      this.disabledButton = true;
      return;
    }

    if (this.booking.room !== '' && this.booking.enumber !== '' && this.booking.bookingTime !== null && this.booking.bookingEndTime !== null) {
      console.log(this.booking);
      this.errorMessage = null;
      this.disabledButton = false;
    } else {
      this.disabledButton = true;
    }
  }

  checkIfEmptyForm() {
    if (this.booking.room !== '' || this.booking.enumber !== '' || this.booking.bookingTime !== null) {
      this.displayFullSize = true;
    } else {
      this.router.navigate(['/bookings'])
    }
  }

  //Gets called by clicking on button, for closing the lightbox || Author: Domenico Winkelmann
  closeModal() {
    this.displayFullSize = false;
  }

}
