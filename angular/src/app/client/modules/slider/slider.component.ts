import { trigger, transition, style, animate } from '@angular/animations';
import { Component, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.scss'],
  animations: [
    trigger('carouselAnimation', [
      transition('void => *', [
        style({ opacity: 0 }),
        animate('300ms', style({ opacity: 1 })),
      ]),
      transition('* => void', [animate('300ms', style({ opacity: 0 }))]),
    ]),
  ],
})
export class AppSliderComponent {
  @Input() sliderContentStringList: string[] = [];
  @Input() type: string = 'bannner';
  @Input() height!: string[];
  currentSlide = 0;
  constructor(private _sanitizer: DomSanitizer) {}

  bypassSecurityTrustHtml(htmlString: string) {
    return this._sanitizer.bypassSecurityTrustHtml(htmlString);
  }

  onPreviousClick() {
    const previous = this.currentSlide - 1;
    this.currentSlide =
      previous < 0 ? this.sliderContentStringList.length - 1 : previous;
    console.log('previous clicked, new current slide is: ', this.currentSlide);
  }

  onNextClick() {
    const next = this.currentSlide + 1;
    this.currentSlide = next === this.sliderContentStringList.length ? 0 : next;
    console.log('next clicked, new current slide is: ', this.currentSlide);
  }
}
