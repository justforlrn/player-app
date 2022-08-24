import { Component, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { isThisSecond } from 'date-fns';
import { TDSDrawerRef, TDSDrawerService } from 'tds-ui/drawer';
import { TDSSafeAny } from 'tds-ui/shared/utility';
import { OrderDto } from '../../models/order.model';
import { ItemCardDTO, ItemDTO, RestaurantDTO } from '../../models/restaurant.dto';
import { OrderService } from '../../services/orders.service';

@Component({
  selector: 'app-group-orders',
  templateUrl: './group-orders.component.html',
  providers: [OrderService],
})
export class GroupOrderComponent {
  isLoading = false;
  card: ItemCardDTO = {
    id: '',
    name: '',
    quantity: 0,
    total: 0,
  };
  totalCount = 0;
  quantity: number = 0;
  empty = false;
  childItemVisible = false;
  cartVisible = false;
  orderId: string;
  orderInfo: OrderDto;
  restaurantInfo: RestaurantDTO;
  @ViewChild('drawerTemplate', { static: false }) drawerTemplate?: TemplateRef<{
    $implicit: { value: string };
    drawerRef: TDSDrawerRef<string>;
  }>;

  @ViewChild('drawerFooter', { static: false }) drawerFooter?: TemplateRef<{}>;

  @ViewChild('drawerTotalTemplate', { static: false }) drawerTotalTemplate?: TemplateRef<{
    $implicit: { value: string };
    drawerRef: TDSDrawerRef<string>;
  }>;

  @ViewChild('drawerTotalFooter', { static: false }) drawerTotalFooter?: TemplateRef<{}>;
  constructor(
    private drawerService: TDSDrawerService,
    private orderService: OrderService,
    private activatedRoute: ActivatedRoute
  ) {
    this.orderId = this.activatedRoute.snapshot.params['orderId'];
  }

  ngOnInit() {
    this.getOrderInfo(this.orderId);
  }

  getOrderInfo(id: string) {
    this.isLoading = true;
    this.orderService.getGroupOrderInfo(id).subscribe((res: OrderDto) => {
      this.orderInfo = res;
      this.restaurantInfo = res.restaurant;
      this.isLoading = false;
    });
  }

  changeQuantity(data: number) {
    if (data < 0) {
      this.quantity = 0;
    } else {
      this.quantity = data;
    }
  }

  openCart(): void {
    const drawerRef = this.drawerService.create({
      title: 'Tính tiền',
      content: this.drawerTotalTemplate,
      footer: this.drawerTotalFooter,
      contentParams: {},
      placement: 'left',
    });
    drawerRef.afterOpen.subscribe(() => {
      console.log('Drawer(Template) open');
    });
    drawerRef.afterClose.subscribe(() => {
      console.log('Drawer(Template) close');
    });
  }
  openChildItem(data: TDSSafeAny): void {
    console.log(data.name);
    const drawerRef = this.drawerService.create({
      title: 'Chọn món',
      content: this.drawerTemplate,
      footer: this.drawerFooter,
      contentParams: {
        value: data,
      },
    });
    drawerRef.afterOpen.subscribe(() => {
      console.log('Drawer(Template) open');
    });
    drawerRef.afterClose.subscribe(() => {
      console.log('Drawer(Template) close');
    });
  }

  closeChildItem(): void {
    this.childItemVisible = false;
  }

  submit(data) {
    this.card.quantity = this.quantity;
    this.card.total = data.priceDiscount * this.quantity;
  }
}
