import { Injectable } from '@angular/core';
import { CoreCommonService } from 'src/app/core';
import { environment } from 'src/environments/environment';
import { ItemCardDTO } from '../models/restaurant.dto';

@Injectable()
export class RestaurantService {
  private apiUrl = environment.apiUrl;
  constructor(private http: CoreCommonService) {}

  // login(body: LoginDto) {
  //   const url = `${this.apiUrl}/auth/login`;
  //   return this.http.connect<UserData>(CoreApiMethodType.post, url, body);
  // }
  // public getValueItem(params: ItemCardDTO) {
  //   return  localStorage.setItem("item", params);
  // }

}
