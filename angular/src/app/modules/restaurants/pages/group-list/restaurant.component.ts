import { Component, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TDSDrawerRef, TDSDrawerService } from 'tds-ui/drawer';
import { TDSSafeAny } from 'tds-ui/shared/utility';
import { ItemCardDTO, ItemDTO, RestaurantDTO } from '../../models/restaurant.dto';
import { RestaurantService } from '../../services/restaurant.service';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  providers: [RestaurantService],
})
export class RestaurantComponent {
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
  restaurantId: string;
  restaurantInfo: RestaurantDTO;
  //= {
  //   "id": "5-CYTXNNKTANNHT6",
  //   "name": "Bonchon - Nhà Thờ",
  //   "star": 0,
  //   "open": "10:00 - 22:00",
  //   "close": "10:00-22:00",
  //   "imageUrl": "https://d1sag4ddilekf6.azureedge.net/compressed_webp/items/5-CYTXNNKTANNHT6-CYTXNNKXKBBGRN/detail/3cab5624871f48d7abea2c681717d569_1608202347261270715.webp",
  //   "webUrl": "",
  //   "items": [
  //     {
  //       "id": "5-CYTXNNKTANNHT6-CYTXNNKXKBBGRN",
  //       "quantity": 1,
  //       "name": "Chicken bites - size S - 6 pcs",
  //       "imageUrl": "https://d1sag4ddilekf6.azureedge.net/compressed_webp/items/5-CYTXNNKTANNHT6-CYTXNNKXKBBGRN/detail/3cab5624871f48d7abea2c681717d569_1608202347261270715.webp",
  //       "priceOrigin": 79000,
  //       "priceDiscount": 67150,
  //       "optionGroups": [
  //         {
  //           "id": "VNMOG2019062810055575953",
  //           "name": "Sauce/Sốt - Size S",
  //           "isAvailable": true,
  //           "selectMin": 1,
  //           "selectMax": 1,
  //           "options": [
  //             {
  //               "id": "VNMOD2019062810055688956",
  //               "name": "Sweet Crunch/ Tỏi Giòn",
  //               "isAvailable": true,
  //               "price": 0
  //             },
  //             {
  //               "id": "VNMOD2019062810055649498",
  //               "name": "Spicy/ Cay",
  //               "isAvailable": true,
  //               "price": 0
  //             },
  //             {
  //               "id": "VNMOD2019062810055615200",
  //               "name": "Original/ Truyền Thống",
  //               "isAvailable": true,
  //               "price": 0
  //             }
  //           ]
  //         }
  //       ]
  //     },
  //     {
  //       "id": "5-CYTXNNKTANNHT6-CYTXNNKXTY62CX",
  //       "quantity": 1,
  //       "name": "Chicken bites - size L - 24 pcs",
  //       "imageUrl": "https://d1sag4ddilekf6.azureedge.net/compressed_webp/items/5-CYTXNNKTANNHT6-CYTXNNKXTY62CX/detail/7e6d207c31404d7391652dbd9829d3d0_1609760530380303728.webp",
  //       "priceOrigin": 309000,
  //       "priceDiscount": 262650,
  //       "optionGroups": [
  //         {
  //           "id": "VNMOG2019062810082615880",
  //           "name": "Sauce/Sốt - Size M & Size L",
  //           "isAvailable": true,
  //           "selectMin": 1,
  //           "selectMax": 2,
  //           "options": [
  //             {
  //               "id": "VNMOD2019062810082654944",
  //               "name": "Sweet Crunch/ Tỏi Giòn",
  //               "isAvailable": true,
  //               "price": 0
  //             },
  //             {
  //               "id": "VNMOD2019062810082693094",
  //               "name": "Spicy/ Cay",
  //               "isAvailable": true,
  //               "price": 0
  //             },
  //             {
  //               "id": "VNMOD2019062810082693597",
  //               "name": "Original/ Truyền Thống",
  //               "isAvailable": true,
  //               "price": 0
  //             }
  //           ]
  //         }
  //       ]
  //     },
  //     {
  //       "id": "VNITE20191227074329014346",
  //       "name": "Tteokbokki fish cake",
  //       "quantity": 1,
  //       "imageUrl": "https://d1sag4ddilekf6.azureedge.net/compressed_webp/items/VNITE20191227074329014346/detail/b5bbe052f46343f9bc65a4d936580a90_1607343931510999875.webp",
  //       "priceOrigin": 119000,
  //       "priceDiscount": 101150,
  //       "optionGroups": []
  //     },
  //     {
  //       "id": "VNITE20211108171107035501",
  //       "quantity": 1,
  //       "name": "Mala Chicken Bites - Size S - 6 Pcs/Gà Không Xương Xốt Mala - Cỡ S - 6 Miếng",
  //       "imageUrl": "https://d1sag4ddilekf6.azureedge.net/compressed_webp/items/VNITE20211108171107035501/detail/206beb7cbc444b89a135a1f158d11f11_1655374479132292844.webp",
  //       "priceOrigin": 89000,
  //       "priceDiscount": 89000,
  //       "optionGroups": []
  //     },
  //     {
  //       "id": "VNITE20211108171107057475",
  //       "quantity": 1,
  //       "name": "Mala Chicken Wings - Size S - 4 Pcs/Cánh Gà Xốt Mala - Cỡ S - 4 Miếng",
  //       "imageUrl": "https://d1sag4ddilekf6.azureedge.net/compressed_webp/items/VNITE20211108171107057475/detail/315bc7e2c6a54e30919c429f93db5105_1655374479758084118.webp",
  //       "priceOrigin": 89000,
  //       "priceDiscount": 89000,
  //       "optionGroups": []
  //     },
  //     {
  //       "id": "VNITE20211108171107070656",
  //       "quantity": 1,
  //       "name": "Mala Chicken Drumsticks - Size S - 2 Pcs/Đùi Gà Xốt Mala - Cỡ S - 2 Miếng",
  //       "imageUrl": "https://d1sag4ddilekf6.azureedge.net/compressed_webp/items/VNITE20211108171107070656/detail/aa13109783104d869768375562bdcbae_1655374480393977131.webp",
  //       "priceOrigin": 89000,
  //       "priceDiscount": 89000,
  //       "optionGroups": []
  //     },
  //     {
  //       "id": "VNITE20211108171108015072",
  //       "quantity": 1,
  //       "name": "Mala Chicken Combo - Size S - 2 Wings + 1 Drumstick",
  //       "imageUrl": "https://d1sag4ddilekf6.azureedge.net/compressed_webp/items/VNITE20211108171108015072/detail/898e847b408b4774b778b550d7baaf79_1646902794613314054.webp",
  //       "priceOrigin": 89000,
  //       "priceDiscount": 89000,
  //       "optionGroups": []
  //     },
  //     {
  //       "id": "VNITE20211108171108022240",
  //       "quantity": 1,
  //       "name": "Mala Chicken Bites - Size M - 12 Pcs/Gà Không Xương Xốt Mala - Cỡ M - 12 Miếng",
  //       "imageUrl": "https://d1sag4ddilekf6.azureedge.net/compressed_webp/items/VNITE20211108171108022240/detail/0316b288af3f49d6aa972f0126589ba6_1655374479391896140.webp",
  //       "priceOrigin": 169000,
  //       "priceDiscount": 169000,
  //       "optionGroups": []
  //     },

  //   ]
  // }

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
    private restaurantService: RestaurantService,
    private activatedRoute: ActivatedRoute
  ) {
    this.restaurantId = this.activatedRoute.snapshot.params['id'];
  }

  ngOnInit() {
    this.getRestaurantInfo(this.restaurantId);
  }

  getRestaurantInfo(id: string) {
    this.restaurantService.getRestaurantInfo(id).subscribe((res: RestaurantDTO) => {
      this.restaurantInfo = res;
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
