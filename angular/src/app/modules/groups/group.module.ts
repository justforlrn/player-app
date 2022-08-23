import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSFormFieldModule } from 'tds-ui/form-field';
import { TDSInputModule } from 'tds-ui/tds-input';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSNotificationModule } from 'tds-ui/notification';
import { TDSEmptyModule } from 'tds-ui/empty';
import { GroupDisplayDashboardComponent } from './pages/group-display-dashboard/group-display-dashboard.component';
import { GroupRoutingModule } from './group-routing.module';
import { GroupListComponent as GroupComponent } from './pages/group/group.component';
import { NewGroupComponent } from './components/new-group.component';
import { TDSModalModule } from 'tds-ui/modal';
import { TDSSelectModule } from 'tds-ui/select';
import { NewGroupOrderComponent } from './components/new-group-order.component';
import { TDSAutocompleteModule } from 'tds-ui/auto-complete';
import { TDSImageModule } from 'tds-ui/image';
import { TDSCheckBoxModule } from 'tds-ui/tds-checkbox';
import { TDSDropDownModule } from 'tds-ui/dropdown';
import { EditGroupComponent } from './components/edit-group.component';

@NgModule({
  declarations: [
    GroupDisplayDashboardComponent,
    GroupComponent,
    NewGroupComponent,
    NewGroupOrderComponent,
    EditGroupComponent,
  ],
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
    TDSModalModule,
    TDSSelectModule,
    FormsModule,
    TDSAutocompleteModule,
    TDSImageModule,
    TDSCheckBoxModule,
    TDSDropDownModule,
  ],
})
export class GroupModule {}
