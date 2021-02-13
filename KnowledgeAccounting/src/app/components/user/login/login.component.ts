import { User } from './../../../interfaces/user';
import { Router } from '@angular/router';
import { UserService } from './../../../services/user/user.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Form, FormBuilder, FormControl, FormGroup, NgForm, NgModel, Validators } from '@angular/forms';
import { StringLiteral } from 'typescript';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: User = { id: '', userName: '', password: '', role: 'Student'};
  ErrorMessage: string = '';
  loginFormModel: FormGroup;

  constructor(private service: UserService, private router: Router) {
  }

  get userName() { return this.loginFormModel.get('userName'); }
  get password() { return this.loginFormModel.get('password'); }

  ngOnInit() {
    this.loginFormModel = this.service.loginFormModel;

    if (localStorage.getItem('token') !== null) {
      this.router.navigate(['home']);
    }
  }

  onSubmit(): void {
    this.ErrorMessage = '';
    if (!this.userName.valid) {
      this.ErrorMessage = 'Username should have length 4-25 and have only letters and digits!';
    }
    else if (!this.password.valid) {
      this.ErrorMessage = 'Password should have length 5-25, only letters and digits, at least 1 upper-case letter and 1 digits';
    }

    if (this.ErrorMessage === '') {
      this.user.userName = this.userName.value;
      this.user.password = this.password.value;
      this.service.login(this.user).subscribe(
        (res: any) => {
          localStorage.setItem('token', res.token);
          this.router.navigateByUrl('/home');
        },
        (error) => {
          console.log(error);
          this.ErrorMessage = error['error'];
        }
      );
    }
  }

}
