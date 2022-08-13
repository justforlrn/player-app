import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GroupDisplayDashboardComponent } from './pages/group-display-dashboard/group-display-dashboard.component';
import { GroupListComponent } from './pages/group-list/group-list.component';

const routes: Routes = [
  {
    path: '',
    component: GroupDisplayDashboardComponent,
  },
  {
    path: 'list',
    component: GroupListComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GroupRoutingModule {}
