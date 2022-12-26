import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TDSBreadCrumbModule } from 'tds-ui/breadcrumb';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSCarouselModule } from 'tds-ui/carousel';
import { TDSDropDownModule } from 'tds-ui/dropdown';
import { TDSImageModule } from 'tds-ui/image';
import { ClientPublicationsComponent } from './publications.component';
@NgModule({
  declarations: [ClientPublicationsComponent],
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
  exports: [],
})
export class ClientPublicationsModule {}
