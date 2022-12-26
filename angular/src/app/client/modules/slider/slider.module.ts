import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpCustomSharedService } from 'src/app/shared/http-custom.shared.service';
import { TDSButtonModule } from 'tds-ui/button';
import { TDSButtonMenuModule } from 'tds-ui/button-menu';
import { TDSCarouselModule } from 'tds-ui/carousel';
import { TDSDropDownModule } from 'tds-ui/dropdown';
import { TDSImageModule } from 'tds-ui/image';
import { AppSliderComponent } from '../../modules/slider/slider.component';

@NgModule({
  declarations: [AppSliderComponent],
  imports: [
    CommonModule,
    TDSImageModule,
    TDSCarouselModule,
    TDSDropDownModule,
    TDSButtonModule,
    TDSButtonMenuModule,
  ],
  providers: [HttpCustomSharedService],
  exports: [AppSliderComponent],
})
export class AppSliderModule {}
