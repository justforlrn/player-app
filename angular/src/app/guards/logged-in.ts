import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { CoreCommonService } from '../core';

@Injectable({
  providedIn: 'root',
})
export class LoggedIn implements CanActivate {
  constructor(private router: Router, private _coreCommonService: CoreCommonService) {}

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const userData = this._coreCommonService.getUserData();
    if (userData?.accessToken == null) {
      return true;
    } else {
      this.router.navigateByUrl('/dashboard');
      return false;
    }
  }
}
