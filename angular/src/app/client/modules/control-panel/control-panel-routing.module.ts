import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppClientHomeComponent } from './client-home.component';

const routes: Routes = [
  {
    path: '',
    component: AppClientHomeComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientHomeRoutingModule {}
