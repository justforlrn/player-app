import { Injectable } from '@angular/core';
import {
  CreateSlider,
  Slider,
} from 'src/app/admin/modules/slider/slider.model';
import { HttpCustomSharedService } from 'src/app/shared/http-custom.shared.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SliderService {
  //private options: any;
  apiUrl = environment.apiUrl;
  constructor(private _httpCustomSharedService: HttpCustomSharedService) {}

  //   public get(url: string, options?: any): Observable<any> {
  //     return this.http
  //       .get(url, options ?? this.options)
  //       .pipe(catchError((error) => this.errorHandling(error)));
  //   }

  public createBanneder(body: CreateSlider) {
    const url = `${environment.apiUrl}/api/slidelist`;
    return this._httpCustomSharedService.post<Slider>(url, body);
  }

  removeSlide(slideId: string) {
    const url = `${environment.apiUrl}/api/slidelist?slideId=${slideId}`;
    return this._httpCustomSharedService.delete(url);
  }

  public createSlider(body: CreateSlider) {
    const url = `${environment.apiUrl}/api/slidelist`;
    return this._httpCustomSharedService.post<Slider>(url, body);
  }

  getListBannerByModuleId(moduleId: string, language: number) {
    const url = `${environment.apiUrl}/api/slidelist?moduleId=${moduleId}&language=${language}`;
    return this._httpCustomSharedService.get<Slider[]>(url);
  }

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
