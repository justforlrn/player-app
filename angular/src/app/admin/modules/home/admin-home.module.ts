import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpCustomSharedService } from 'src/app/shared/http-custom.shared.service';
import { TDSEditorModule } from 'tds-editor';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSCarouselModule } from 'tds-ui/carousel';
import { TDSCollapseModule } from 'tds-ui/collapse';
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
import { AppSliderModule } from '../slider/slider.module';
import { AdminHomeRoutingModule } from './admin-home-routing.module';
import { AdminHomeComponent } from './admin-home.component';

@NgModule({
  declarations: [AdminHomeComponent],
  imports: [
    CommonModule,
    AdminHomeRoutingModule,
    TDSImageModule,
    TDSCarouselModule,
    TDSDropDownModule,
    TDSButtonModule,
    TDSButtonMenuModule,
    RouterModule,
    AppSliderModule,
    TDSCollapseModule,
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
  providers: [HttpCustomSharedService],
  exports: [AdminHomeComponent],
})
export class AdminHomeModule {}
