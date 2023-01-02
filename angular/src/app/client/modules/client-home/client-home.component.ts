import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import {
  Indicator,
  Information,
  Module,
} from 'src/app/admin/modules/home/admin-home.model';
import { HomeService } from 'src/app/admin/modules/home/admin-home.service';
import { AppLabels } from 'src/app/shared/app.constants';
import { SharedService } from 'src/app/shared/shared.service';
import { environment } from 'src/environments/environment';
import { SliderService } from '../slider/slider.service';
import { ClientHomeContent } from './client-home.model';

@Component({
  selector: 'app-client-home',
  templateUrl: './client-home.component.html',
  providers: [SliderService, HomeService],
})
export class AppClientHomeComponent {
  appLabels!: AppLabels;
  pageData!: ClientHomeContent;
  bannerImageUrlList: string[] = [];
  sliderContentList: string[] = [];
  // moduleId = '428811ff-0838-6fd0-7afb-3a0855a4d5eb';

  introduction!: Information;
  // backupIntroduceHtmlCode: string = '';

  informationList: Information[] = [];

  homeModule!: Module;
  language = 0;
  listIndicator!: Indicator[];
  constructor(
    private _sharedService: SharedService,
    private _sliderService: SliderService,
    private _homeService: HomeService,
    private _sanitizer: DomSanitizer
  ) {
    this.language = this._sharedService._language;
    this.appLabels = this._sharedService.language;
  }

  getModuleHome() {
    this._homeService.getModule(this.language).subscribe((res) => {
      if (res && res?.length) {
        let target = res.find((e) => e.moduleName == 'home');
        if (target) {
          this.homeModule = target;
          this.getListSlider(this.homeModule.id);
          this.getInformationList();
        }
      }
    });
  }

  ngOnInit() {
    this.pageData = this._sharedService.demo_getHomePage();
    this.getModuleHome();
    this._homeService.getlistIndicator(this.language).subscribe(res => {
      this.listIndicator = res;
      console.log(this.listIndicator)
    })
  }
  getListSlider(moduleId: string) {
    this._sliderService
      .getListBannerByModuleId(moduleId, this.language)
      .subscribe((res) => {
        if (res && !!res.length) {
          res.forEach((slider) => {
            if (slider.slideType == 0) {
              this.bannerImageUrlList.push(
                `${environment.apiUrl}/${slider.imageUrl}`
              );
            }
            if (slider.slideType == 1) {
              this.sliderContentList.push(slider.slideContent);
            }
          });
          this.bannerImageUrlList = [...this.bannerImageUrlList];
        }
      });
  }
  getInformationList() {
    this._homeService
      .getInformationList(this.homeModule.id, this.language)
      .subscribe((res) => {
        this.informationList = res;
        let introduction = res.find((e) => e.keyName == 'introduction');
        if (introduction) {
          this.introduction = introduction;
          //   // this.introduceHtmlCode = introduction.content;
          //   // this.backupIntroduceHtmlCode = introduction.content;
        }
      });
  }
  bypassSecurityTrustHtml(htmlString: string) {
    // htmlString = htmlString.replace(
    //   'src=',
    //   `style="height: ${this.height[2] - 70}px;" src=`
    // );
    return this._sanitizer.bypassSecurityTrustHtml(htmlString);
  }
}
