import { Component } from '@angular/core';
import { AppLabels } from 'src/app/shared/app.constants';
import { SharedService } from 'src/app/shared/shared.service';

@Component({
  selector: 'app-admin',
  template: ` <router-outlet></router-outlet> `,
})
export class AdminComponent {
  appLabels!: AppLabels;
  // pageData!: ClientHomeContent;
  constructor(private _sharedService: SharedService) {
    this.appLabels = this._sharedService.language;
  }
  ngOnInit() {
    // this.pageData = this._sharedService.demo_getHomePage();
  }
}
