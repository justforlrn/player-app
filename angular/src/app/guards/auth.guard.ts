import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { CoreCommonService } from '../core';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private _router: Router, private _coreCommonService: CoreCommonService) {}

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const userData = this._coreCommonService.getUserData();
    if (userData?.accessToken != null) {
      return true;
    } else {
      console.log(state.url);
      this._coreCommonService.backupUnreachedUrl(state.url);
      this._router.navigateByUrl('/users/login');
      return false;
    }
  }
}
