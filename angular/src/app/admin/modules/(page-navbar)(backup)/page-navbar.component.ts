import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AppLabels } from 'src/app/shared/app.constants';
import { SharedService } from 'src/app/shared/shared.service';

@Component({
  selector: 'app-page-navbar',
  templateUrl: './page-navbar.component.html',
})
export class AppPageNavbarComponent {
  headerContent!: string;
  appLabels!: AppLabels;
  constructor(private _router: Router, private _sharedService: SharedService) {
    this.appLabels = this._sharedService.language;
  }
  ngOnInit() {
    console.log(this._router.url);
    switch (this._router.url) {
      case '/about-us': {
        this.headerContent = this.appLabels.header.AboutUs;
        break;
      }
      case '/report-cards': {
        this.headerContent = this.appLabels.header.ReportCard;
        break;
      }
    }
  }
}
