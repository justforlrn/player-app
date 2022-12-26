import { Component } from '@angular/core';
import { AppLabels } from 'src/app/shared/app.constants';
import { SharedService } from 'src/app/shared/shared.service';
import { TDSMessageService } from 'tds-ui/message';
import { TDSHelperObject } from 'tds-ui/shared/utility/helper-object';
import {
  Information,
  Module,
  UpdateInformation,
} from '../home/admin-home.model';
import { HomeService } from '../home/admin-home.service';
import { ReportCard } from './report-card.model';

@Component({
  selector: 'app-client-report-card',
  templateUrl: './report-card.component.html',
  styles: [':host { height: 100%}'],
  providers: [HomeService],
})
export class AppClientReportCardComponent {
  appLabels!: AppLabels;
  pageData!: ReportCard;
  language = 0;
  reportCardModule!: Module;
  reportCardInformation!: Information;
  backupReportCardInformation!: Information;
  constructor(
    private _sharedService: SharedService,
    private _homeService: HomeService,
    private _msg: TDSMessageService
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

  // cancel() {
  //   this.isEditIntroduction = false;
  //   if (this.introductionInformation && this.backupIntroduceHtmlCode) {
  //     this.introductionInformation.content = this.backupIntroduceHtmlCode;
  //   }
  // }

  save() {
    if (
      this.reportCardInformation
      //  && this.reportCardInformation.content !=
      //     this.backupReportCardInformation.content) ||
      // this.reportCardInformation.title != this.backupReportCardInformation.title
    ) {
      const body: UpdateInformation = {
        informationId: this.reportCardInformation.id,
        title: this.reportCardInformation.title,
        content: this.reportCardInformation.content,
        icon: '',
        keyName: this.reportCardInformation.keyName,
      };
      this._homeService.updateIntroduce(body).subscribe((res) => {
        this.reportCardInformation = res;
        this.backupReportCardInformation = res;
        this._msg.success('Cập nhật thành công');
        // this.isEditIntroduction = false;
        console.log('res', res);
      });
    }
  }
}
