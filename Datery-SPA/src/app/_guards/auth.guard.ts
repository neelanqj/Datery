import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService) {}
  canActivate(): boolean {
      if (this.authService.loggedIn()) {
        return true;
      }

      // if the user is not logged in
      this.alertify.error('You need to be logged in to access this area');

      // redirect the user to the homepage
      this.router.navigate(['/home']);

      return false;
  }
}
