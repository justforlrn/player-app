import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TDSImageModule } from 'tds-ui/image';
import { TDSTableModule } from 'tds-ui/table';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSModalModule } from 'tds-ui/modal';
import { TDSFormFieldModule } from 'tds-ui/form-field';
import { TDSInputModule } from 'tds-ui/tds-input';
import { FormsModule } from '@angular/forms';
import { TDSSpinnerModule } from 'tds-ui/progress-spinner';
import { TDSAutocompleteModule } from 'tds-ui/auto-complete';
import { TDSMessageModule } from 'tds-ui/message';
import { UserRoutingModule } from './user-routing.module';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSNotificationModule } from 'tds-ui/notification';
import { LoginComponent } from './pages/login/login.component';

@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    TDSNotificationModule,
    ScrollingModule,
    TDSFormFieldModule,
    TDSInputModule,
    TDSButtonModule,
    TDSButtonMenuModule,
    TDSButtonModule,
    UserRoutingModule,
    TDSMessageModule,
  ],
})
export class UserModule {}
