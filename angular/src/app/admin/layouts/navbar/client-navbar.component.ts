import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppLabels, Language } from 'src/app/shared/app.constants';
import { SharedService } from 'src/app/shared/shared.service';
import { NavElements } from './client-navbar.model';
@Component({
  selector: 'app-client-navbar',
  templateUrl: './client-navbar.component.html',
})
export class AppClientNavbarComponent {
  appLabels!: AppLabels;
  data!: NavElements;
  isShowMobileMenu = false;
  constructor(private _sharedService: SharedService) {
    this.appLabels = this._sharedService.language;
  }

  showMobileMenu() {
    this.isShowMobileMenu = true;
  }

  closeMobileMenu(): void {
    this.isShowMobileMenu = false;
  }

  ngOnInit() {
    // this.currentRoute = this.router.
    this.data = {
      LogoUrl: '/assets/imgs/logos/nav-logo.png',
      WebTitle: 'Active Healthy Kids Viet Nam',
    };
  }

  switchLanguage(language: Language) {
    this.appLabels = this._sharedService.switchLanguage(language);
  }
}
