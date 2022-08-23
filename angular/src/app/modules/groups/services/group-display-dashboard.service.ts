import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CoreApiMethodType, CoreCommonService } from 'src/app/core';
import { environment } from 'src/environments/environment';
import { UserData } from '../../users/models/users/user-data.model';
import { CreateGroup } from '../models/create-group.model';
import { Group } from '../models/group.model';

@Injectable()
export class GroupDisplayDashboardService {
  private apiUrl = environment.apis.default.url;
  private currentUser!: UserData;
  constructor(private _coreCommonService: CoreCommonService) {
    this.currentUser = this._coreCommonService.getUserData();
  }
  public getJoinedGroupList(): Observable<Group[]> {
    const url = `${this.apiUrl}/groups/get-by-current`;
    return this._coreCommonService.connect<Group[]>(CoreApiMethodType.get, url, null);
  }
  public createGroup(data: CreateGroup): Observable<Group[]> {
    const url = `${this.apiUrl}/groups`;
    return this._coreCommonService.connect<Group[]>(CoreApiMethodType.post, url, data);
  }
  public deleteGroup(id: string) {
    debugger;
    const url = `${this.apiUrl}/groups/${id}`;
    return this._coreCommonService.connect<Group[]>(CoreApiMethodType.delete, url, null);
  }
}
