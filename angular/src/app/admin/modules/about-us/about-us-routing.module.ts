import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppClientAboutUsComponent } from './about-us.component';

const routes: Routes = [
  {
    path: '',
    component: AppClientAboutUsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientAboutUsRoutingModule {}
