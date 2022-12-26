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
import { ReportCard } from './report-card.model';

@Component({
  selector: 'app-client-report-card',
  templateUrl: './report-card.component.html',
  styles: [':host { height: 100%}'],
  providers: [HomeService, HttpCustomSharedService],
})
export class AppClientReportCardComponent {
  appLabels!: AppLabels;
  pageData!: ReportCard;
  reportCardModule!: Module;
  reportCardInformation!: Information;
  backupReportCardInformation!: Information;
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
  getReportcard(reportCardKey: string) {
    this._homeService.getModule(this.language).subscribe((res) => {
      if (res && res?.length) {
        let target = res.find((e) => e.moduleName == reportCardKey);
        if (target) {
          this.reportCardModule = target;
          this.getReportCardInformation(reportCardKey);
        }
      }
    });
  }
  getReportCardInformation(reportCardKey: string) {
    this._homeService
      .getInformationList(this.reportCardModule.id, this.language)
      .subscribe((res) => {
        if (res && res.length) {
          let reportCardInformation = res.find(
            (e) => e.keyName == reportCardKey
          );
          if (reportCardInformation) {
            this.reportCardInformation = reportCardInformation;
            this.backupReportCardInformation = JSON.parse(
              JSON.stringify(reportCardInformation)
            );
          }
        }
      });
  }
  ngOnInit() {
    this.pageData = this._sharedService.demo_getReportCard();
    this.getReportcard('reportcard2022');
  }
  bypassSecurityTrustHtml(htmlString: string) {
    return this._sanitizer.bypassSecurityTrustHtml(htmlString);
  }
}
