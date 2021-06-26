import {ModuleWithProviders} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { BookingCreateComponent } from './booking-create/booking-create.component';
import { BookingsComponent } from './bookings/bookings.component';
import { BookingDetailComponent } from './booking-detail/booking-detail.component';

export const appRoutes: Routes = [
  {path: 'bookings', component: BookingsComponent},
  {path: 'create-booking', component: BookingCreateComponent},
  {path: 'booking/:id', component: BookingDetailComponent},
  {path: '', redirectTo: '/bookings', pathMatch: 'full'}

];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes, {useHash: true});
