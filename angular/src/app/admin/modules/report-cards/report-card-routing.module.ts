import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { AppClientReportCardReportsComponent } from './components/reports/client-report-card-reports.component';
import { AppClientReportCardComponent } from './report-card.component';

const routes: Routes = [
  {
    path: '',
    component: AppClientReportCardComponent,
    children: [
      {
        path: '',
        component: AppClientReportCardComponent,
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AppClientReportCardRoutingModule {}
