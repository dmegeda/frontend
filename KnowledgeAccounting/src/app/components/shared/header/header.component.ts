import { Router } from '@angular/router';
import { UserService } from './../../../services/user/user.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {


  constructor(private service: UserService, private router: Router) { }

  ngOnInit() {
  }

  get userName() {
    if (this.isAuthorized()) {
      return this.service.getCurrentUserData().UserName;
    }
    return 'Guest';
  }

  isAuthorized(): boolean{
    if (localStorage.getItem('token') !== null) {
      return true;
    }
    return false;
  }

  logout() {
    this.service.logout();
    this.router.navigate(['home']);
  }
}
