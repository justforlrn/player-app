import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSFormFieldModule } from 'tds-ui/form-field';
import { TDSInputModule } from 'tds-ui/tds-input';
import { TDSMessageModule } from 'tds-ui/message';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { ReactiveFormsModule } from '@angular/forms';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSNotificationModule } from 'tds-ui/notification';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { DashboardRoutingModule } from './dashboard-routing.module';

@NgModule({
  declarations: [DashboardComponent],
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
    DashboardRoutingModule,
    TDSMessageModule,
  ],
})
export class DashboardModule {}
