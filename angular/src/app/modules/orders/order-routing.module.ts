import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroupOrderComponent } from './pages/group-orders/group-orders.component';

const routes: Routes = [
  // {
  //   path: ':id',
  //   component: RestaurantComponent,
  // },
  {
    path: '',
    component: GroupOrderComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrderRoutingModule {}
