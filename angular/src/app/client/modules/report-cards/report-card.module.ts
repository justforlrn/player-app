import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TDSBreadCrumbModule } from 'tds-ui/breadcrumb';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSCarouselModule } from 'tds-ui/carousel';
import { TDSDropDownModule } from 'tds-ui/dropdown';
import { TDSImageModule } from 'tds-ui/image';
import { TDSTabsModule } from 'tds-ui/tabs';
import { AppClientReportCardRoutingModule } from './report-card-routing.module';
import { AppClientReportCardComponent } from './report-card.component';

@NgModule({
  declarations: [AppClientReportCardComponent],
  imports: [
    CommonModule,
    TDSImageModule,
    TDSCarouselModule,
    TDSDropDownModule,
    TDSButtonModule,
    TDSButtonMenuModule,
    RouterModule,
    AppClientReportCardRoutingModule,
    TDSTabsModule,
    TDSBreadCrumbModule,
  ],
  providers: [],
  exports: [],
})
export class AppClientReportCardModule {}
