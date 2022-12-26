import { Component } from '@angular/core';
import { AppLabels } from 'src/app/shared/app.constants';
import { SharedService } from 'src/app/shared/shared.service';
import { AboutUs } from './about-us.model';

@Component({
  selector: 'app-client-about-us',
  templateUrl: './about-us.component.html',
  styles: [':host { height: 100%}'],
})
export class AppClientAboutUsComponent {
  appLabels!: AppLabels;
  pageData!: AboutUs;
  constructor(private _sharedService: SharedService) {
    this.appLabels = this._sharedService.language;
  }
  ngOnInit() {
    this.pageData = this._sharedService.demo_getAboutUs();
  }
}
