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
import { TDSEmptyModule } from 'tds-ui/empty';
import { RestaurantComponent } from './pages/group-list/restaurant.component';
import { RestaurantRoutingModule } from './restaurant-routing.module';
import { TDSImageModule } from 'tds-ui/image';
import { TDSDrawerModule } from 'tds-ui/drawer';
import { CartComponent } from './components/carts/cart.component';

@NgModule({
  declarations: [RestaurantComponent, CartComponent],
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
    RestaurantRoutingModule,
    TDSImageModule,
    TDSDrawerModule,
  ],
})
export class RestaurantModule {}
