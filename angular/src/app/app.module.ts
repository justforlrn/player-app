import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { TDS_I18N, vi_VN } from 'tds-ui/i18n';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { DragDropModule } from '@angular/cdk/drag-drop';
// Đa ngôn ngữ
import localeVi from '@angular/common/locales/vi';
import { registerLocaleData } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { UserModule } from './modules/users/user.module';
import { HttpClientModule } from '@angular/common/http';
import { CoreModule } from './core/lib.module';
import { TDSMenuModule } from 'tds-ui/menu';
import { LayoutModule } from '@angular/cdk/layout';
import { RouterModule } from '@angular/router';
import { LayoutComponent } from './shared/layouts/layout.component';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSModalModule } from 'tds-ui/modal';
import { TDSAutocompleteModule } from 'tds-ui/auto-complete';
// Thiết lập tiếng Việt
registerLocaleData(localeVi);
@NgModule({
  declarations: [AppComponent, LayoutComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    DragDropModule,
    ScrollingModule,
    HttpClientModule,
    CoreModule,
    UserModule,
    TDSButtonModule,
    TDSModalModule,
    TDSAutocompleteModule 
  ],
  providers: [{ provide: TDS_I18N, useValue: vi_VN }],
  bootstrap: [AppComponent],
})
export class AppModule {}

// import { AccountConfigModule } from '@abp/ng.account/config';
// import { CoreModule } from '@abp/ng.core';
// import { registerLocale } from '@abp/ng.core/locale';
// import { IdentityConfigModule } from '@abp/ng.identity/config';
// import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
// import { TenantManagementConfigModule } from '@abp/ng.tenant-management/config';
// import { ThemeBasicModule } from '@abp/ng.theme.basic';
// import { ThemeSharedModule } from '@abp/ng.theme.shared';
// import { NgModule } from '@angular/core';
// import { BrowserModule } from '@angular/platform-browser';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { environment } from '../environments/environment';
// import { AppRoutingModule } from './app-routing.module';
// import { AppComponent } from './app.component';
// import { APP_ROUTE_PROVIDER } from './route.provider';

// @NgModule({
//   imports: [
//     BrowserModule,
//     BrowserAnimationsModule,
//     AppRoutingModule,
//     CoreModule.forRoot({
//       environment,
//       registerLocaleFn: registerLocale(),
//     }),
//     ThemeSharedModule.forRoot(),
//     AccountConfigModule.forRoot(),
//     IdentityConfigModule.forRoot(),
//     TenantManagementConfigModule.forRoot(),
//     SettingManagementConfigModule.forRoot(),
//     ThemeBasicModule.forRoot(),
//   ],
//   declarations: [AppComponent],
//   providers: [APP_ROUTE_PROVIDER],
//   bootstrap: [AppComponent],
// })
// export class AppModule {}
