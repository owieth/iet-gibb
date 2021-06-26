import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {AuthService} from '../../service/auth.service';
import {Router} from '@angular/router';
import {SnackbarService} from '../../service/snackbar.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  signUpFormGroup: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private snackBarService: SnackbarService, private router: Router) {
  }

  ngOnInit(): void {
    this.signUpFormGroup = this.fb.group({
      lastname: ['', Validators.required],
      firstname: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  signUpUser(): void {
    this.authService.signUp(this.signUpFormGroup.value).subscribe(res => {
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
