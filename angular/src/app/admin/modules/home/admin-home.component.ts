import { HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { AppLabels } from 'src/app/shared/app.constants';
import { HttpCustomSharedService } from 'src/app/shared/http-custom.shared.service';
import { SharedService } from 'src/app/shared/shared.service';
import { environment } from 'src/environments/environment';
import { TDSMessageService } from 'tds-ui/message';
import { TDSModalService } from 'tds-ui/modal';
import { TDSUploadFile } from 'tds-ui/upload';
import { CreateSlider, Slider } from '../slider/slider.model';
import { SliderService } from '../slider/slider.service';
import {
  CreateIndicator,
  CreateInformation,
  Indicator,
  Information,
  Module,
  UpdateInformation,
} from './admin-home.model';
import { HomeService } from './admin-home.service';
const getBase64 = (file: File): Promise<string | ArrayBuffer | null> =>
  new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = (error) => reject(error);
  });

@Component({
  selector: 'app-client-home',
  templateUrl: './admin-home.component.html',
  providers: [SliderService, HomeService],
})
export class AdminHomeComponent {
  appLabels!: AppLabels;
  addNewAnnouncement = false;
  newSliderData!: CreateSlider;
  annouceImageData!: CreateSlider;
  submitNewAnnounce = false;
  bannerList: TDSUploadFile[] = [
  ];
  sliderList: Slider[] = [];
  previewImage: string | undefined = '';
  previewVisible = false;

  newAnnounceText: string = '';
  // introduceHtmlCode: string = '';
  backupIntroduceHtmlCode: string = '';
  informationList: Information[] = [];
  introductionInformation?: Information;
  isEditIntroduction = false;

  language = 0;

  homeModule!: Module;
  isVisible = false;
  indicatorImageList: TDSUploadFile[] = [
  ];

  newIndicator!: CreateIndicator;
  listIndicator!: Indicator[];
  constructor(
    private _sharedService: SharedService,
    // private _httpCustomSharedService: HttpCustomSharedService,
    private _sliderService: SliderService,
    private _msg: TDSMessageService,
    private _sanitizer: DomSanitizer,
    private _homeService: HomeService,
    private _modal: TDSModalService
  ) {
    this.language = this._sharedService._language;
    this.appLabels = this._sharedService.language;
  }

  clickAddIndicator() {
    this.indicatorImageList = [];
    this.isVisible = true;
    this.newIndicator = {
      indicatorIcon: "",
      indicatorTitle: "",
      benchmark: "",
      gradeIcon: "",
      gradeContent: "",
      keyFindings: "",
      reference: "",
      language: 0
    }
  }

  handleOk(): void {
    if(this.indicatorImageList && this.indicatorImageList.length > 0) {
      this.newIndicator.indicatorIcon = `${environment.apiUrl}${JSON.parse(JSON.stringify(this.indicatorImageList[0])).response.imageUrl}`
    }
    this.newIndicator.language = this.language;
    console.log(this.newIndicator);
    this._homeService.createIndicator(this.newIndicator).subscribe(res => {
      this._msg.success("Thành công");
    })
    this.isVisible = false;
  }

  handleCancel(): void {
    console.log("Button cancel clicked!");
    this.isVisible = false;
  }

  initDatabaseModule() {
    this.newSliderData = {
      slideTitle: '',
      slideContent: '',
      slideType: 0,
      imageUrl: '',
      slideOder: 0,
      moduleId: this.homeModule.id,
      language: this.language,
    };
    this.annouceImageData = {
      slideTitle: '',
      slideContent: '',
      slideType: 1,
      imageUrl: '',
      slideOder: 0,
      moduleId: this.homeModule.id,
      language: this.language,
    };
  }

  showEditIntroduction(event: any) {
    event.stopPropagation();
    this.isEditIntroduction = true;
  }

  bypassSecurityTrustHtml(htmlString: string) {
    return this._sanitizer.bypassSecurityTrustHtml(htmlString);
  }
  getListSlider(moduleId: string) {
    this._sliderService
      .getListBannerByModuleId(moduleId, this.language)
      .subscribe((res) => {
        this.sliderList = [];
        this.bannerList = [];
        if (res && !!res.length) {
          res.forEach((slider) => {
            if (slider.slideType == 0) {
              this.bannerList.push({
                uid: slider.id,
                name: slider.imageUrl,
                status: 'done',
                url: `${environment.apiUrl}/${slider.imageUrl}`,
              });
            }
            if (slider.slideType == 1) {
              this.sliderList.push(slider);
            }
          });
          // this.bannerList = [...this.bannerList];
        }
      });
  }
  ngOnInit() {
    // this.pageData = this._sharedService.demo_getHomePage();
    // this.getListBanner(this.moduleId);
    this._homeService.getlistIndicator(this.language).subscribe(res => {
      this.listIndicator = res;
      console.log(this.listIndicator)
    })
    this.getModuleHome();
  }
  onAddNewAnnouncement() {
    this.addNewAnnouncement = true;
  }

  removeSlideAnno(slide: any) {
    return this._sliderService.removeSlide(slide.id).subscribe({
      next: () => {
        this.sliderList = this.sliderList.filter((e) => e.id != slide.id);
        this._msg.success('Xóa thành công');
      },
      error: () => {
        this._msg.error('Thất bại');
      },
    });
  }

  handleRemove = (file: TDSUploadFile) => {
    return new Observable<any>((res) => {
      this._modal.warning({
        title: 'Xóa file ' + file.name,
        content: 'Bạn xác nhận xóa file ' + file.name,
        onOk: () => {
          this._sliderService.removeSlide(file.uid).subscribe({
            next: () => {
              this._msg.success('Xóa ảnh thành công');
            },
            error: () => {
              this._msg.error('Thất bại');
            },
          });
          res.next(true);
          res.complete();
          this._msg.success('Xóa file thành công');
        },
        onCancel: () => {
          res.next(false);
          res.complete();
          this._msg.info('Bạn đã hủy xóa file');
        },
        okText: 'Xóa file',
        cancelText: 'Hủy',
      });
    });
  };

  handlePreview = async (file: TDSUploadFile) => {
    if (!file.url && !file.preview) {
      file.preview = await getBase64(file.originFileObj!);
    }
    this.previewImage = file.url || file.preview;
    this.previewVisible = true;
  };
  handleUpload = (item: any) => {
    const formData = new FormData();
    formData.append('ufile', item.file as any, item.file.name);
    const url = `${environment.apiUrl}/api/file/uploadimage`;
    return this._homeService.uploadImage(url, formData).subscribe(
      (res: any) => {
        if (res && res.imageUrl) {
          item.file.url = res.imageUrl;
          this.newSliderData.imageUrl = res.imageUrl;
          this._sliderService
            .createBanneder(this.newSliderData)
            .subscribe((res) => {
              this._msg.success('Tải ảnh lên thành công');
            });
        }
        item.onSuccess(res, item.file);
      },
      (err) => {
        item.onError({ statusText: err.error?.error?.details }, item.file);
      }
    );
  };
  handleUploadIndicatorImage = (item: any) => {
    const formData = new FormData();
    formData.append('ufile', item.file as any, item.file.name);
    const url = `${environment.apiUrl}/api/file/uploadimage`;
    return this._homeService.uploadImage(url, formData).subscribe(
      (res: any) => {
        // if (res && res.imageUrl) {
        //   item.file.url = res.imageUrl;
        //   this.newSliderData.imageUrl = res.imageUrl;
        //   this._sliderService
        //     .createBanneder(this.newSliderData)
        //     .subscribe((res) => {
        //       this._msg.success('Tải ảnh lên thành công');
        //     });
        // }
        item.onSuccess(res, item.file);
      },
      (err) => {
        item.onError({ statusText: err.error?.error?.details }, item.file);
      }
    );
  };
  handleDownload = (file: TDSUploadFile) => {
    window.open(file.response.url);
  };

  customUpload = (blobInfo: any, success: any, failure: any) => {
    const formData = new FormData();
    formData.append('ufile', blobInfo.blob(), blobInfo.filename());
    const url = `${environment.apiUrl}/api/file/uploadimage`;
    return this._homeService
      .uploadImage(url, formData)
      .subscribe((res: any) => {
        if (res && res.imageUrl) {
          this.annouceImageData.imageUrl = res.imageUrl;
          success(res.imageUrl);
          failure('Tải ảnh lên thất bại');
          // this._msg.success('Tải ảnh lên thành công');
        }
      });
  };

  cancelNewAnnounce() {
    this.annouceImageData.imageUrl = '';
    this.annouceImageData.slideContent = '';
    this.annouceImageData.slideTitle = '';
    this.newAnnounceText = '';
    this.addNewAnnouncement = false;
    this.submitNewAnnounce = false;
  }

  saveNewAnnounce() {
    this.submitNewAnnounce = true;
    console.log(this.annouceImageData, this.newAnnounceText);
    if (this.newAnnounceText != '' && this.annouceImageData.slideTitle != '') {
      this.annouceImageData.slideContent = this.newAnnounceText.replace(
        'localhost/images',
        'images'
      );
      this._sliderService
        .createSlider(this.annouceImageData)
        .subscribe((res) => {
          this.submitNewAnnounce = false;
          this.addNewAnnouncement = false;
          this.annouceImageData.imageUrl = '';
          this.annouceImageData.slideContent = '';
          this.annouceImageData.slideTitle = '';
          this.newAnnounceText = '';
          this.sliderList.push(res);
        });
    }
  }

  getModuleHome() {
    this._homeService.getModule(this.language).subscribe((res) => {
      if (res && res?.length) {
        let target = res.find((e) => e.moduleName == 'home');
        if (target) {
          this.homeModule = target;
          this.initDatabaseModule();
          this.getListSlider(this.homeModule.id);
          this.getInformationList();
        }
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
          this.introductionInformation = introduction;
          this.backupIntroduceHtmlCode = introduction.content;
        }
      });
  }
  cancelIntroduce() {
    this.isEditIntroduction = false;
    if (this.introductionInformation && this.backupIntroduceHtmlCode) {
      this.introductionInformation.content = this.backupIntroduceHtmlCode;
    }
  }

  saveIntroduce() {
    if (
      this.introductionInformation &&
      this.introductionInformation.content != this.backupIntroduceHtmlCode
    ) {
      const body: UpdateInformation = {
        informationId: this.introductionInformation.id,
        title: '',
        content: this.introductionInformation.content,
        icon: '',
        keyName: this.introductionInformation.keyName,
      };
      this._homeService.updateIntroduce(body).subscribe((res) => {
        this.introductionInformation = res;
        this.backupIntroduceHtmlCode = res.content;
        this._msg.success('Cập nhật thành công');
        this.isEditIntroduction = false;
        console.log('res', res);
      });
    }
  }
}
