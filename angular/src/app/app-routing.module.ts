import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { ClientLayoutComponent } from './layouts/client-layout/client-layout.component';
// import { ClientEventComponent } from './modules/event/event.component';
// import { ClientLoginComponent } from './modules/login/login.component';
// import { ClientPublicationsComponent } from './modules/publications/publications.component';
// import { ClientPublicationsModule } from './modules/publications/publications.module';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
          import('./client/client.module').then(
            (m) => m.ClientModule
          ),
  },
  {
    path: 'admin',
    loadChildren: () =>
          import('./admin/admin.module').then(
            (m) => m.AdminModule
          ),
  },
  { path: '*', redirectTo: '' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      relativeLinkResolution: 'legacy',
      useHash: true,
      scrollPositionRestoration: 'enabled'
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
