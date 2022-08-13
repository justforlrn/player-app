import { Component } from '@angular/core';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
})
export class RestaurantComponent {
  empty = false;
  visible = false;
  constructor() {}
  open(): void {
    this.visible = true;
  }

  close(): void {
    this.visible = false;
  }
}
