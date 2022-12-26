import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TDSBreadCrumbModule } from 'tds-ui/breadcrumb';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSCarouselModule } from 'tds-ui/carousel';
import { TDSDrawerModule } from 'tds-ui/drawer';
import { TDSDropDownModule } from 'tds-ui/dropdown';
import { TDSImageModule } from 'tds-ui/image';
import { ClientLayoutComponent } from './client-layout.component';
import { AppClientNavbarComponent } from './navbar/client-navbar.component';

@NgModule({
  declarations: [ClientLayoutComponent, AppClientNavbarComponent],
  imports: [
    CommonModule,
    TDSImageModule,
    TDSCarouselModule,
    TDSDropDownModule,
    TDSButtonModule,
    TDSButtonMenuModule,
    RouterModule,
    TDSDrawerModule,
    TDSBreadCrumbModule,
  ],
  providers: [],
  exports: [ClientLayoutComponent],
})
export class AppClientLayoutModule {}
