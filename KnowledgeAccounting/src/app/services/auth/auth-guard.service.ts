import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private auth: AuthService, private router: Router) { }

  canActivate(): boolean{
    if (!this.auth.isAuthenticated()) {
      this.router.navigate(['home']);
      console.log('not auth');
      return false;
    }
    return true;
  }

}
