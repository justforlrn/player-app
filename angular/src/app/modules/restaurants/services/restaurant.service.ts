import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CoreApiMethodType, CoreCommonService } from 'src/app/core';
import { environment } from 'src/environments/environment';
import { ItemCardDTO, RestaurantDTO } from '../models/restaurant.dto';

@Injectable()
export class RestaurantService {
  private apiUrl = environment.apis.default.url;
  constructor(private http: CoreCommonService) {}

  public getRestaurantInfo(id: string): Observable<RestaurantDTO> {
    const url = `${this.apiUrl}/restaurants?id=${id}`;
    return this.http.connect<RestaurantDTO>(CoreApiMethodType.get, url, null);
  }
  // login(body: LoginDto) {
  //   const url = `${this.apiUrl}/auth/login`;
  //   return this.http.connect<UserData>(CoreApiMethodType.post, url, body);
  // }
  // public getValueItem(params: ItemCardDTO) {
  //   return  localStorage.setItem("item", params);
  // }
}
