import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CoreCommonService } from 'src/app/core';
import { UserData } from 'src/app/modules/users/models/users/user-data.model';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
})
export class LayoutComponent {
  currentUser: UserData;
  constructor(private _router: Router, private _coreCommonService: CoreCommonService) {
    this.currentUser = this._coreCommonService.getUserData();
  }

  ngOnInit() {
    this._coreCommonService.onUserEmit().subscribe(res => {
      this.currentUser = res;
    });
  }

  public off() {
    localStorage.clear();
    this.currentUser = null;
    this._router.navigateByUrl('/users/login');
  }
}
