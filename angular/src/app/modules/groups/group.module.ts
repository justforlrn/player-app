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
import { TDSMenuModule } from 'tds-ui/menu';
import { TDSEmptyModule } from 'tds-ui/empty';
import { RouterModule } from '@angular/router';
import { GroupDisplayDashboardComponent } from './pages/group-display-dashboard/group-display-dashboard.component';
import { GroupRoutingModule } from './group-routing.module';
import { GroupListComponent } from './pages/group-list/group-list.component';

@NgModule({
  declarations: [GroupDisplayDashboardComponent, GroupListComponent],
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
    TDSEmptyModule,
    GroupRoutingModule,
  ],
})
export class GroupModule {}
