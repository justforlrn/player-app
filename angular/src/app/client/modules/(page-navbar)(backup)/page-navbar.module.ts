import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TDSBreadCrumbModule } from 'tds-ui/breadcrumb';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSCarouselModule } from 'tds-ui/carousel';
import { TDSDropDownModule } from 'tds-ui/dropdown';
import { TDSImageModule } from 'tds-ui/image';
import { AppSliderComponent } from '../../modules/slider/slider.component';
import { AppPageNavbarComponent } from './page-navbar.component';

@NgModule({
  declarations: [AppPageNavbarComponent],
  imports: [
    CommonModule,
    TDSImageModule,
    TDSCarouselModule,
    TDSDropDownModule,
    TDSButtonModule,
    TDSButtonMenuModule,
    TDSBreadCrumbModule,
  ],
  providers: [],
  exports: [AppPageNavbarComponent],
})
export class AppPageNavbarModule {}
