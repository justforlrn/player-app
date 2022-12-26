import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TDSBreadCrumbModule } from 'tds-ui/breadcrumb';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSCarouselModule } from 'tds-ui/carousel';
import { TDSDropDownModule } from 'tds-ui/dropdown';
import { TDSFormFieldModule } from 'tds-ui/form-field';
import { TDSImageModule } from 'tds-ui/image';
import { TDSMessageModule } from 'tds-ui/message';
import { TDSNotificationModule } from 'tds-ui/notification';
import { TDSInputModule } from 'tds-ui/tds-input';
import { ClientRoutingModule } from './client-routing.module';
import { ClientComponent } from './client.component';
import { AppClientLayoutModule } from './layouts/client-layout.module';
import { ClientEventComponent } from './modules/event/event.component';
import { ClientLoginComponent } from './modules/login/login.component';
import { ClientPublicationsModule } from './modules/publications/publications.module';

@NgModule({
  declarations: [ClientComponent, ClientEventComponent, ClientLoginComponent],
  imports: [
    CommonModule,
    TDSImageModule,
    TDSCarouselModule,
    TDSDropDownModule,
    TDSButtonModule,
    TDSButtonMenuModule,
    RouterModule,
    AppClientLayoutModule,
    ClientRoutingModule,
    ClientPublicationsModule,
    TDSBreadCrumbModule,
    TDSFormFieldModule,
    TDSInputModule,
    HttpClientModule,
    TDSNotificationModule,
    TDSMessageModule,
    FormsModule,
    ReactiveFormsModule,

  ],
  providers: [],
  exports: [ClientComponent],
})
export class ClientModule {}
