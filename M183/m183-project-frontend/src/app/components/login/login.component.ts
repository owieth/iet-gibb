import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../service/auth.service';
import {Router} from '@angular/router';
import {SnackbarService, SnackBarType} from '../../service/snackbar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginFormGroup: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private snackBarService: SnackbarService) {
  }

  ngOnInit(): void {
    this.loginFormGroup = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  loginUser(): void {
    if (this.loginFormGroup.valid) {
      this.authService.login(this.loginFormGroup.value).subscribe(res => {
          // @ts-ignore
          if (res.body.message) {
            this.authService.setToken(res.headers.get('access_token'));
            this.router.navigateByUrl('');
          }
        },
        (err => {
          this.snackBarService.openSnackBar(`${err.error}`);
        }));
    }
  }
}
