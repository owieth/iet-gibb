import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {CommandComponent} from './components/command/command.component';
import {AuthGuard} from './core/auth.guard';
import {LoginComponent} from './components/login/login.component';
import {SignupComponent} from './components/signup/signup.component';

const routes: Routes = [
  {
    path: '', component: CommandComponent, canActivate: [AuthGuard]
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'signup', component: SignupComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
