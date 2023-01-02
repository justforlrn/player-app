import { Component } from '@angular/core';
import { AppLabels } from 'src/app/shared/app.constants';
import { HttpCustomSharedService } from 'src/app/shared/http-custom.shared.service';
import { SharedService } from 'src/app/shared/shared.service';
import { environment } from 'src/environments/environment';
import { TDSMessageService } from 'tds-ui/message';
import {
  Information,
  Module,
  UpdateInformation,
} from '../home/admin-home.model';
import { HomeService } from '../home/admin-home.service';
// import { AboutUs } from './about-us.model';

@Component({
  selector: 'app-client-publications',
  templateUrl: './publications.component.html',
  providers: [HttpCustomSharedService, HomeService],
  // styles: [':host { height: 100%}'],
})
export class ClientPublicationsComponent {
  appLabels!: AppLabels;
  // pageData!: AboutUs;
  publicationModule!: Module;
  publicationInformation!: Information;
  backupPublicationInformation!: Information;
  language = 0;
  constructor(
    private _sharedService: SharedService,
    private _homeService: HomeService,
    private _msg: TDSMessageService
  ) {
    this.language = this._sharedService._language;
    this.appLabels = this._sharedService.language;
  }
  
  customUpload = (blobInfo: any, success: any, failure: any) => {
    const formData = new FormData();
    formData.append('ufile', blobInfo.blob(), blobInfo.filename());
    const url = `${environment.apiUrl}/api/file/uploadimage`;
    return this._homeService
      .uploadImage(url, formData)
      .subscribe((res: any) => {
        if (res && res.imageUrl) {
          // this.annouceImageData.imageUrl = res.imageUrl;
          success(res.imageUrl);
          failure('Tải ảnh lên thất bại');
          // this._msg.success('Tải ảnh lên thành công');
        }
      });
  };


  getPublication(publicationKey: string) {
    this._homeService.getModule(this.language).subscribe((res) => {
      if (res && res?.length) {
        let target = res.find((e) => e.moduleName == publicationKey);
        if (target) {
          this.publicationModule = target;
          this.getPublicationInformation(publicationKey);
        }
      }
    });
  }
  getPublicationInformation(publicationKey: string) {
    this._homeService
      .getInformationList(this.publicationModule.id, this.language)
      .subscribe((res) => {
        if (res && res.length) {
          let publicationInformation = res.find(
            (e) => e.keyName == publicationKey
          );
          if (publicationInformation) {
            this.publicationInformation = publicationInformation;
            this.backupPublicationInformation = JSON.parse(
              JSON.stringify(publicationInformation)
            );
          }
        }
      });
  }
  ngOnInit() {
    // this.pageData = this._sharedService.demo_getReportCard();
    this.getPublication('publication');
  }
  save() {
    if (
      this.publicationInformation
      //  && this.publicationInformation.content !=
      //     this.backuppublicationInformation.content) ||
      // this.publicationInformation.title != this.backuppublicationInformation.title
    ) {
      const body: UpdateInformation = {
        informationId: this.publicationInformation.id,
        title: this.publicationInformation.title,
        content: this.publicationInformation.content,
        icon: '',
        keyName: this.publicationInformation.keyName,
      };
      this._homeService.updateIntroduce(body).subscribe((res) => {
        this.publicationInformation = res;
        this.backupPublicationInformation = res;
        this._msg.success('Cập nhật thành công');
        // this.isEditIntroduction = false;
        console.log('res', res);
      });
    }
  }
}
