import { Injectable } from '@angular/core';
import {
    CanActivate,
    ActivatedRouteSnapshot,
    RouterStateSnapshot,
    Router
} from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    constructor(private router: Router) { }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const accessToken = localStorage.getItem("accessToken");
        if (accessToken != null) {
          return true;
        } else {
          this.router.navigateByUrl('/users/login');
          return false;
        } 
    }
}