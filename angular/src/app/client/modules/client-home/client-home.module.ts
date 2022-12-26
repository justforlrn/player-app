import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSCarouselModule } from 'tds-ui/carousel';
import { TDSDropDownModule } from 'tds-ui/dropdown';
import { TDSEmptyModule } from 'tds-ui/empty';
import { TDSImageModule } from 'tds-ui/image';
import { TDSTabsModule } from 'tds-ui/tabs';
import { AppSliderModule } from '../slider/slider.module';
import { ClientHomeRoutingModule } from './client-home-routing.module';
import { AppClientHomeComponent } from './client-home.component';

@NgModule({
  declarations: [AppClientHomeComponent],
  imports: [
    CommonModule,
    ClientHomeRoutingModule,
    TDSImageModule,
    TDSCarouselModule,
    TDSDropDownModule,
    TDSButtonModule,
    TDSButtonMenuModule,
    RouterModule,
    AppSliderModule,
    TDSEmptyModule,
  ],
  providers: [],
  exports: [AppClientHomeComponent],
})
export class AppClientHomeModule {}
