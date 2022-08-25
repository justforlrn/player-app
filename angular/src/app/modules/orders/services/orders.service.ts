import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CoreApiMethodType, CoreCommonService } from 'src/app/core';
import { environment } from 'src/environments/environment';
import { TDSSafeAny } from 'tds-ui/shared/utility';
import { OrderDto as GroupOrderDto } from '../models/order.model';
import { ItemCardDTO, RestaurantDTO } from '../models/restaurant.dto';
import { UserCreateOderDTO } from '../models/user-order.model';

@Injectable()
export class OrderService {
  private apiUrl = environment.apis.default.url;
  constructor(private http: CoreCommonService) {}

  public getGroupOrderInfo(id: string): Observable<GroupOrderDto> {
    const url = `${this.apiUrl}/group-orders?groupOrderId=${id}`;
    return this.http.connect<GroupOrderDto>(CoreApiMethodType.get, url, null);
  }

  public userCreateOrder(params: UserCreateOderDTO): Observable<TDSSafeAny> {
    const url = `${this.apiUrl}/user-order`;
    return this.http.connect<TDSSafeAny>(CoreApiMethodType.post, url, null);
  }
  // login(body: LoginDto) {
  //   const url = `${this.apiUrl}/auth/login`;
  //   return this.http.connect<UserData>(CoreApiMethodType.post, url, body);
  // }
  // public getValueItem(params: ItemCardDTO) {
  //   return  localStorage.setItem("item", params);
  // }
}
