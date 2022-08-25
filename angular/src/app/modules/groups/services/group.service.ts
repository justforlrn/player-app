import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CoreApiMethodType, CoreCommonService } from 'src/app/core';
import { environment } from 'src/environments/environment';
import { UserData } from '../../users/models/users/user-data.model';
import { Group } from '../models/group.model';

@Injectable()
export class GroupService {
  private apiUrl = environment.apis.default.url;
  private currentUser!: UserData;
  constructor(private _coreCommonService: CoreCommonService) {
    this.currentUser = this._coreCommonService.getUserData();
  }
  // public getGroupOrderList(groupId: string): Observable<Group[]> {
  //   const listOrderGroup: Group[] = [];
  // }

  public onSearchRestaurant(name: any) {
    const url = `${this.apiUrl}/restaurants/get-minimized-list?content=${name}`;
    return this._coreCommonService.connect<any>(CoreApiMethodType.get, url, null);
  }

  public onGetRestaurant(url: string) {
    var url = `${this.apiUrl}/restaurants/grab-crawler?url=${url}`;
    return this._coreCommonService.connect<any>(CoreApiMethodType.get, url, null);
  }

  public createGroupOrder(data: any) {
    var url = `${this.apiUrl}/group-orders`;
    return this._coreCommonService.connect<any>(CoreApiMethodType.post, url, data);
  }

  public getGroupOrderList(groupId: string) {
    const url = `${this.apiUrl}/group-orders/get-list-by-group-id?groupId=${groupId}`;
    return this._coreCommonService.connect<any>(CoreApiMethodType.get, url, null);
  }

  public deleteGroupOrder(id: string) {
    const url = `${this.apiUrl}/group-orders?id=${id}`;
    return this._coreCommonService.connect<Group[]>(CoreApiMethodType.delete, url, null);
  }
  // login(body: LoginDto) {
  //   const url = `${this.apiUrl}/auth/login`;
  //   return this.http.connect<UserData>(CoreApiMethodType.post, url, body);
  // }
}
