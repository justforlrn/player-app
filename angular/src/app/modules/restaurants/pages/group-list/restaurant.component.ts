import { Component } from '@angular/core';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
})
export class RestaurantComponent {
  empty = false;
  childItemVisible = false;
  cartVisible = false
  constructor() {}
  openChildItem(): void {
    this.childItemVisible = true;
  }

  closeChildItem(): void {
    this.childItemVisible = false;
  }

  openCart(): void {
    this.cartVisible = true;
  }

  closeCart(): void {
    this.cartVisible = false;
  }
}
