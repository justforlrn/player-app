import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TDSBreadCrumbModule } from 'tds-ui/breadcrumb';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSCarouselModule } from 'tds-ui/carousel';
import { TDSDropDownModule } from 'tds-ui/dropdown';
import { TDSImageModule } from 'tds-ui/image';
import { ClientAboutUsRoutingModule } from './about-us-routing.module';
import { AppClientAboutUsComponent } from './about-us.component';

@NgModule({
  declarations: [AppClientAboutUsComponent],
  imports: [
    CommonModule,
    TDSImageModule,
    TDSCarouselModule,
    TDSDropDownModule,
    TDSButtonModule,
    TDSButtonMenuModule,
    ClientAboutUsRoutingModule,
    TDSBreadCrumbModule,
  ],
  providers: [],
  exports: [],
})
export class AppClientAboutUsModule {}
