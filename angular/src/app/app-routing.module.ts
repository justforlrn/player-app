import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthGuard } from './guards/auth.guard';
import { LayoutComponent } from './shared/layouts/layout.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    // redirectTo: '/dashboard',
    children: [
      {
        path: '',
        redirectTo: '/users/login',
        pathMatch: 'full',
      },
      {
        path: 'users',
        loadChildren: () => import('./modules/users/user.module').then(m => m.UserModule),
      },
      {
        path: 'dashboard',
        canActivate: [AuthGuard],
        loadChildren: () =>
          import('./modules/dashboard/dashboard.module').then(m => m.DashboardModule),
      },
      {
        path: 'groups',
        canActivate: [AuthGuard],
        loadChildren: () => import('./modules/groups/group.module').then(m => m.GroupModule),
      },
      {
        path: 'restaurant',
        canActivate: [AuthGuard],
        loadChildren: () =>
          import('./modules/restaurants/restaurant.module').then(m => m.RestaurantModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
