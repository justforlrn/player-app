import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import {
  Information,
  Module,
} from 'src/app/admin/modules/home/admin-home.model';
import { HomeService } from 'src/app/admin/modules/home/admin-home.service';
import { AppLabels } from 'src/app/shared/app.constants';
import { HttpCustomSharedService } from 'src/app/shared/http-custom.shared.service';
import { SharedService } from 'src/app/shared/shared.service';
import { TDSMessageService } from 'tds-ui/message';
// import { AboutUs } from './about-us.model';

@Component({
  selector: 'app-client-event',
  templateUrl: './event.component.html',
  providers: [HttpCustomSharedService, HomeService],
  // styles: [':host { height: 100%}'],
})
export class ClientEventComponent {
  appLabels!: AppLabels;
  eventModule!: Module;
  eventInformation!: Information;
  backupEventInformationInformation!: Information;
  language = 0;
  constructor(
    private _sharedService: SharedService,
    private _homeService: HomeService,
    private _msg: TDSMessageService,
    private _sanitizer: DomSanitizer
  ) {
    this.language = this._sharedService._language;
    this.appLabels = this._sharedService.language;
  }
  getEventInformation(eventInformationKey: string) {
    this._homeService.getModule(this.language).subscribe((res) => {
      if (res && res?.length) {
        let target = res.find((e) => e.moduleName == eventInformationKey);
        if (target) {
          this.eventModule = target;
          this.getEventInformationInformation(eventInformationKey);
        }
      }
    });
  }
  getEventInformationInformation(eventInformationKey: string) {
    this._homeService
      .getInformationList(this.eventModule.id, this.language)
      .subscribe((res) => {
        if (res && res.length) {
          let eventInformation = res.find(
            (e) => e.keyName == eventInformationKey
          );
          if (eventInformation) {
            this.eventInformation = eventInformation;
            this.backupEventInformationInformation = JSON.parse(
              JSON.stringify(eventInformation)
            );
          }
        }
      });
  }
  ngOnInit() {
    // this.pageData = this._sharedService.demo_getEventInformation();
    this.getEventInformation('event');
  }
  bypassSecurityTrustHtml(htmlString: string) {
    return this._sanitizer.bypassSecurityTrustHtml(htmlString);
  }
}
