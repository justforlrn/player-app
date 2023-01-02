import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpCustomSharedService } from 'src/app/shared/http-custom.shared.service';
import {
  CreateIndicator,
  CreateInformation,
  Indicator,
  Information,
  Module,
  UpdateInformation,
} from './admin-home.model';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  //private options: any;
  apiUrl = environment.apiUrl;
  constructor(private _httpCustomSharedService: HttpCustomSharedService) {}

  //   public get(url: string, options?: any): Observable<any> {
  //     return this.http
  //       .get(url, options ?? this.options)
  //       .pipe(catchError((error) => this.errorHandling(error)));
  //   }

  getlistIndicator(language: number) {
    const url = `${environment.apiUrl}/api/reports?language=${language}`;
    return this._httpCustomSharedService.get<Indicator[]>(url);
  }

  createIndicator(body: CreateIndicator) {
    const url = `${environment.apiUrl}/api/reports`;
    return this._httpCustomSharedService.post<Indicator>(url, body);
  }

  getModule(language: number) {
    const url = `${environment.apiUrl}/api/module?language=${language}`;
    return this._httpCustomSharedService.get<Module[]>(url);
  }

  createIntroduce(body: CreateInformation) {
    const url = `${environment.apiUrl}/api/information`;
    return this._httpCustomSharedService.post<Information>(url, body);
  }
  updateIntroduce(body: UpdateInformation) {
    const url = `${environment.apiUrl}/api/information`;
    return this._httpCustomSharedService.put<Information>(url, body);
  }

  getInformationList(moduleId: string, language: number) {
    const url = `${environment.apiUrl}/api/information?moduleId=${moduleId}&language=${language}`;
    return this._httpCustomSharedService.get<Information[]>(url);
  }

  uploadImage(url: string, formData: FormData) {
    let _options: any = {};
    _options.headers = new HttpHeaders({});
    return this._httpCustomSharedService.post<any>(url, formData, _options);
  }

  //   getListBannerByModuleId(moduleId: string, language: number) {
  //     const url = `${environment.apiUrl}/api/slidelist?moduleId=${moduleId}&language=${language}`;
  //     return this._httpCustomSharedService.get<Slider[]>(url);
  //   }

  //   public put(url: string, body: any, options?: any): Observable<any> {
  //     return this.http
  //       .put(url, body, options ?? this.options)
  //       .pipe(catchError((error) => this.errorHandling(error)));
  //   }

  //   public delete(url: string, options?: any): Observable<any> {
  //     return this.http
  //       .delete(url, options ?? this.options)
  //       .pipe(catchError((error) => this.errorHandling(error)));
  //   }
}
