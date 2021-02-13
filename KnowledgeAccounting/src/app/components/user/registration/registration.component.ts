import { Router } from '@angular/router';
import { UserService } from './../../../services/user/user.service';
import { User } from './../../../interfaces/user';
import { FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  user: User = { id: '', userName: '', password: '', role: 'Student'};
  ErrorMessage: string = '';
  registerFormModel: FormGroup;

  constructor(private service: UserService, private router: Router) { }

  ngOnInit() {
    if (localStorage.getItem('token') !== null) {
      this.router.navigate(['home']);
    }
    this.registerFormModel = this.service.registerFormModel;
  }

  get userName() { return this.registerFormModel.get('userName'); }
  get password() { return this.registerFormModel.get('password'); }
  get confirmPassword() { return this.registerFormModel.get('confirmPassword'); }

  ComparePasswords(): boolean {
    console.log(this.password.value);
    console.log(this.confirmPassword.value);
    if (this.password.value !== this.confirmPassword.value) {
      return false;
    }
    return true;
  }

  onSubmit(): void {
    this.ErrorMessage = '';
    if (!this.userName.valid) {
      this.ErrorMessage = 'Username should have length 4-25 and have only letters and digits!';
    }
    else if (!this.password.valid) {
      this.ErrorMessage = 'Password should have length 5-25, only letters and digits, at least 1 upper-case letter and 1 digits';
    }
    else if (!this.ComparePasswords()) {
      this.ErrorMessage = 'Passwords do not match';
    }

    if (this.ErrorMessage === '') {
      this.user.userName = this.userName.value;
      this.user.password = this.password.value;
      this.service.register(this.user).subscribe(
        (res: any) => {
          localStorage.setItem('token', res.token);
          this.router.navigate(['home']);
        },
        (error) => {
          console.log(error);
          this.ErrorMessage = error['error'];
        }
      );
    }
  }
}
