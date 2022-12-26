import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientLayoutComponent } from './layouts/client-layout.component';
import { ClientEventComponent } from './modules/event/event.component';
import { ClientLoginComponent } from './modules/login/login.component';
import { ClientPublicationsComponent } from './modules/publications/publications.component';

const routes: Routes = [
  {
    path: '',
    component: ClientLayoutComponent,
     children: [
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
      },

      {
        path: 'home',
        loadChildren: () =>
          import('./modules/home/admin-home.module').then(
            (m) => m.AdminHomeModule
          ),
        // pathMatch: 'full',
      },
      {
        path: 'report-cards',
        data: {
          breadcrumb: 'Report Card 2022',
        },
        loadChildren: () =>
          import('./modules/report-cards/report-card.module').then(
            (m) => m.AppClientReportCardModule
          ),
        // pathMatch: 'full',
      },
      {
        path: 'about-us',
        data: {
          breadcrumb: 'About Us',
        },
        loadChildren: () =>
          import('./modules/about-us/about-us.module').then(
            (m) => m.AppClientAboutUsModule
          ),
      },
      {
        path: 'publications',
        data: {
          breadcrumb: 'Publications',
        },
        component: ClientPublicationsComponent,
      },
      {
        path: 'event',
        data: {
          breadcrumb: 'Event',
        },
        component: ClientEventComponent,
      },
      {
        path: 'login',
        data: {
          breadcrumb: 'Login',
        },
        component: ClientLoginComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
