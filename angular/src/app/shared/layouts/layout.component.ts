import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CoreCommonService } from 'src/app/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
})
export class LayoutComponent {
  constructor(private _router: Router, private _coreCommonService: CoreCommonService) {}
  public isLogged(): boolean {
    return !!this._coreCommonService.getUserData();
  }
  public off() {
    localStorage.clear();
    this._router.navigateByUrl('/users/login');
  }
}
