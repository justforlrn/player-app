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
// import { AppClientLayoutModule } from './layouts/client-layout/client-layout.module';
import { TDSBreadCrumbModule } from 'tds-ui/breadcrumb';
// import { ClientPublicationsComponent } from './modules/publications/publications.component';
// import { ClientEventComponent } from './modules/event/event.component';
import { TDSFormFieldModule } from 'tds-ui/form-field';
import { TDSInputModule } from 'tds-ui/tds-input';
// import { ClientLoginComponent } from './modules/login/login.component';
import { TDSButtonModule } from 'tds-ui/button';
import { HttpClientModule } from '@angular/common/http';
import { TDSNotificationModule } from 'tds-ui/notification';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TDSMessageModule } from 'tds-ui/message';
// Thiết lập tiếng Việt
registerLocaleData(localeVi);
@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    DragDropModule,
    ScrollingModule,
    // AppClientLayoutModule,
  ],
  providers: [{ provide: TDS_I18N, useValue: vi_VN }],
  bootstrap: [AppComponent],
})
export class AppModule {}
