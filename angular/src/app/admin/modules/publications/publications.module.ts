import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TDSEditorModule } from 'tds-editor';
import { TDSBreadCrumbModule } from 'tds-ui/breadcrumb';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSCarouselModule } from 'tds-ui/carousel';
import { TDSDropDownModule } from 'tds-ui/dropdown';
import { TDSEmptyModule } from 'tds-ui/empty';
import { TDSFormFieldModule } from 'tds-ui/form-field';
import { TDSImageModule } from 'tds-ui/image';
import { TDSMessageModule } from 'tds-ui/message';
import { TDSModalModule } from 'tds-ui/modal';
import { TDSInputModule } from 'tds-ui/tds-input';
import { TDSToolTipModule } from 'tds-ui/tooltip';
import { TDSTypographyModule } from 'tds-ui/typography';
import { TDSUploadModule } from 'tds-ui/upload';
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
    TDSFormFieldModule,
    TDSInputModule,
    TDSEditorModule,
    FormsModule,
    TDSTypographyModule,
    TDSUploadModule,
    TDSModalModule,
    TDSMessageModule,
    TDSEmptyModule,
    TDSToolTipModule,
  ],
  providers: [],
  exports: [],
})
export class ClientPublicationsModule {}
