import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
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
import { TDSNotificationModule } from 'tds-ui/notification';
import { TDSInputModule } from 'tds-ui/tds-input';
import { TDSToolTipModule } from 'tds-ui/tooltip';
import { TDSTypographyModule } from 'tds-ui/typography';
import { TDSUploadModule } from 'tds-ui/upload';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { AppClientLayoutModule } from './layouts/client-layout.module';
import { ClientEventComponent } from './modules/event/event.component';
import { ClientLoginComponent } from './modules/login/login.component';
import { ClientPublicationsModule } from './modules/publications/publications.module';

@NgModule({
  declarations: [AdminComponent, ClientEventComponent, ClientLoginComponent],
  imports: [
    CommonModule,
    TDSImageModule,
    TDSCarouselModule,
    TDSDropDownModule,
    TDSButtonModule,
    TDSButtonMenuModule,
    RouterModule,
    AppClientLayoutModule,
    AdminRoutingModule,
    ClientPublicationsModule,
    TDSBreadCrumbModule,
    TDSFormFieldModule,
    TDSInputModule,
    HttpClientModule,
    TDSNotificationModule,
    TDSMessageModule,
    ReactiveFormsModule,
    TDSEditorModule,
    FormsModule,
    TDSTypographyModule,
    TDSUploadModule,
    TDSModalModule,
    TDSEmptyModule,
    TDSToolTipModule,
  ],
  providers: [],
  exports: [AdminComponent],
})
export class AdminModule {}
