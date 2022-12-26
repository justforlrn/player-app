import { Component } from '@angular/core';
import { AppLabels } from 'src/app/shared/app.constants';
import { HttpCustomSharedService } from 'src/app/shared/http-custom.shared.service';
import { SharedService } from 'src/app/shared/shared.service';
import { TDSMessageService } from 'tds-ui/message';
import {
  Information,
  Module,
  UpdateInformation,
} from '../home/admin-home.model';
import { HomeService } from '../home/admin-home.service';
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
  backupEventInformation!: Information;
  language: number;
  constructor(
    private _sharedService: SharedService,
    private _homeService: HomeService,
    private _msg: TDSMessageService
  ) {
    this.language = this._sharedService._language;
    this.appLabels = this._sharedService.language;
  }
  getEvent(eventKey: string) {
    this._homeService.getModule(this.language).subscribe((res) => {
      if (res && res?.length) {
        let target = res.find((e) => e.moduleName == eventKey);
        if (target) {
          this.eventModule = target;
          this.getEventInformation(eventKey);
        }
      }
    });
  }
  getEventInformation(eventKey: string) {
    this._homeService
      .getInformationList(this.eventModule.id, this.language)
      .subscribe((res) => {
        if (res && res.length) {
          let eventInformation = res.find((e) => e.keyName == eventKey);
          if (eventInformation) {
            this.eventInformation = eventInformation;
            this.backupEventInformation = JSON.parse(
              JSON.stringify(eventInformation)
            );
          }
        }
      });
  }
  ngOnInit() {
    // this.pageData = this._sharedService.demo_getReportCard();
    this.getEvent('event');
  }
  save() {
    if (
      this.eventInformation
      //  && this.eventInformation.content !=
      //     this.backupeventInformation.content) ||
      // this.eventInformation.title != this.backupeventInformation.title
    ) {
      const body: UpdateInformation = {
        informationId: this.eventInformation.id,
        title: this.eventInformation.title,
        content: this.eventInformation.content,
        icon: '',
        keyName: this.eventInformation.keyName,
      };
      this._homeService.updateIntroduce(body).subscribe((res) => {
        this.eventInformation = res;
        this.backupEventInformation = res;
        this._msg.success('Cập nhật thành công');
        // this.isEditIntroduction = false;
        console.log('res', res);
      });
    }
  }
}
