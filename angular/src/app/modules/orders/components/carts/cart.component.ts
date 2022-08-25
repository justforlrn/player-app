import { Component } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
})
export class CartComponent {
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
