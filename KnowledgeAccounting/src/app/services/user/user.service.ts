import { Observable } from 'rxjs';
import { User } from './../../interfaces/user';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  userNameControl: FormControl = new FormControl('', Validators.compose([
    Validators.required,
    Validators.minLength(4),
    Validators.maxLength(25),
    Validators.pattern('^[A-Za-z0-9]+$')]));

  passwordControl: FormControl = new FormControl('', Validators.compose([
    Validators.required,
    Validators.minLength(5),
    Validators.maxLength(25),
    Validators.pattern('^[A-Za-z0-9]+$')]));

  confirmPasswordControl: FormControl = new FormControl('', Validators.compose([
    Validators.required,
    Validators.minLength(5),
    Validators.maxLength(25),
    Validators.pattern('^[A-Za-z0-9]+$')]));

  loginFormModel: FormGroup = new FormGroup({
    userName: this.userNameControl,
    password: this.passwordControl
  });

  registerFormModel: FormGroup = new FormGroup({
    userName: this.userNameControl,
    password: this.passwordControl,
    confirmPassword: this.confirmPasswordControl
  });

  private url = 'https://localhost:44366/api/account';

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  register(user: User) {
    return this.http.post(this.url + '/register', user);
  }

  login(user: User) {
    return this.http.post(this.url + '/login', user);
  }

  logout(): void {
    if (localStorage.getItem('token') != null) {
      localStorage.removeItem('token');
    }
  }

  getCurrentUserData(): any{
    const token = localStorage.getItem('token');
    if (token != null) {
      return jwt_decode(token);
    }
    return '';
  }
}
