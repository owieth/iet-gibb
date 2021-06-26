import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { routing } from './app.routes';
import { BookingsComponent } from './bookings/bookings.component';
import { BookingCreateComponent } from './booking-create/booking-create.component';
import { BookingDetailComponent } from './booking-detail/booking-detail.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableModule } from '@sbb-esta/angular-public/table';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatepickerModule } from '@sbb-esta/angular-public/datepicker';
import { LinksModule } from '@sbb-esta/angular-public/links';
import { ButtonModule } from '@sbb-esta/angular-public/button';
import { IconTrashModule } from '@sbb-esta/angular-icons';
import { IconPenModule } from '@sbb-esta/angular-icons';
import { LightboxComponent } from './lightbox/lightbox.component';
import { HeaderModule } from '@sbb-esta/angular-business/header'
import {UserMenuModule} from '@sbb-esta/angular-public';
import {CalendarModule} from 'primeng/calendar';
import { IconArrowsUpDownModule } from '@sbb-esta/angular-icons';

@NgModule({
  declarations: [
    AppComponent,
    BookingsComponent,
    BookingCreateComponent,
    BookingDetailComponent,
    LightboxComponent
  ],
  imports: [
    routing,
    BrowserModule,
    TableModule,
    HttpClientModule,
    BrowserAnimationsModule,
    DatepickerModule,
    FormsModule,
    ReactiveFormsModule,
    LinksModule,
    IconTrashModule,
    IconPenModule,
    ButtonModule,
    IconPenModule,
    HeaderModule,
    UserMenuModule,
    CalendarModule,
    IconArrowsUpDownModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
