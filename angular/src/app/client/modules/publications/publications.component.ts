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
  selector: 'app-client-publications',
  templateUrl: './publications.component.html',
  providers: [HttpCustomSharedService, HomeService],
  // styles: [':host { height: 100%}'],
})
export class ClientPublicationsComponent {
  appLabels!: AppLabels;
  publicationModule!: Module;
  publicationInformation!: Information;
  backupPublicationInformationInformation!: Information;
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
  getPublicationInformation(publicationInformationKey: string) {
    this._homeService.getModule(this.language).subscribe((res) => {
      if (res && res?.length) {
        let target = res.find((e) => e.moduleName == publicationInformationKey);
        if (target) {
          this.publicationModule = target;
          this.getPublicationInformationInformation(publicationInformationKey);
        }
      }
    });
  }
  getPublicationInformationInformation(publicationInformationKey: string) {
    this._homeService
      .getInformationList(this.publicationModule.id, this.language)
      .subscribe((res) => {
        if (res && res.length) {
          let publicationInformation = res.find(
            (e) => e.keyName == publicationInformationKey
          );
          if (publicationInformation) {
            this.publicationInformation = publicationInformation;
            this.backupPublicationInformationInformation = JSON.parse(
              JSON.stringify(publicationInformation)
            );
          }
        }
      });
  }
  ngOnInit() {
    // this.pageData = this._sharedService.demo_getPublicationInformation();
    this.getPublicationInformation('publication');
  }
  bypassSecurityTrustHtml(htmlString: string) {
    return this._sanitizer.bypassSecurityTrustHtml(htmlString);
  }
}
