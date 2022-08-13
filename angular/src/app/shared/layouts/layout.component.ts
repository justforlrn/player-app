import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
})
export class LayoutComponent {
  constructor(private _router: Router) {}
  public off() {
    localStorage.clear();
    this._router.navigateByUrl('/users/login');
  }
}
