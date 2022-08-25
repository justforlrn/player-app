import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroupDisplayDashboardComponent } from './pages/group-display-dashboard/group-display-dashboard.component';
import { GroupListComponent } from './pages/group/group.component';

const routes: Routes = [
  {
    path: '',
    component: GroupDisplayDashboardComponent,
  },
  {
    path: ':id',
    children: [
      {
        path: '',
        component: GroupListComponent,
        pathMatch: 'full',
      },
      {
        path: ':orderId',
        loadChildren: () => import('../orders/order.module').then(m => m.OrderModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GroupRoutingModule {}
