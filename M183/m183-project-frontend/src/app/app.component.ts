import {Component, OnInit} from '@angular/core';
import {AuthService} from './service/auth.service';
import {Router} from '@angular/router';
import {SnackbarService} from './service/snackbar.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private authService: AuthService, private snackBarService: SnackbarService, private router: Router) {
  }

  ngOnInit(): void {
    this.authService.verify().subscribe((res) => {
        // @ts-ignore
        if (res.body.token && this.router.url !== '/signup') {
          this.router.navigateByUrl('');
        }
      },
      (err => {
        if (err.error.error === 'jwt expired') {
          localStorage.removeItem('access_token');
          this.snackBarService.openSnackBar('Token is expired! Please login again');
        } else {
          this.snackBarService.openSnackBar(`${err.error}`);
        }
      }));
  }
}
