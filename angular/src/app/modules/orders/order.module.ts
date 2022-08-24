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
import { TDSImageModule } from 'tds-ui/image';
import { TDSDrawerModule } from 'tds-ui/drawer';
import { CartComponent } from './components/carts/cart.component';
import { TDSRadioModule } from 'tds-ui/radio';
import { GroupOrderComponent } from './pages/group-orders/group-orders.component';
import { OrderRoutingModule } from './order-routing.module';
import { TDSSpinnerModule } from 'tds-ui/progress-spinner';

@NgModule({
  declarations: [GroupOrderComponent, CartComponent],
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
    OrderRoutingModule,
    TDSImageModule,
    TDSDrawerModule,
    TDSRadioModule,
    FormsModule,
    TDSSpinnerModule,
  ],
})
export class OrderModule {}
