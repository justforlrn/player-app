import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CoreApiMethodType, CoreCommonService } from 'src/app/core';
import { environment } from 'src/environments/environment';
import { UserData } from '../../users/models/users/user-data.model';
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
    // const listGroup: Group[] = [];
    // var g1: Group = {
    //   Id: "4",
    //   Name: 'Lầu 4',
    //   Members: [
    //     this.currentUser
    //   ]
    // }
    // var g2: Group = {
    //   Id: "2",
    //   Name: 'Lầu 2',
    //   Members: [
    //     this.currentUser
    //   ]
    // }
    // listGroup.push(g1)
    // listGroup.push(g2)
    // var ob = new Observable<Group[]>((obs) => {
    //   obs.next(listGroup);
    // });
    // return ob;
  }
  // login(body: LoginDto) {
  //   const url = `${this.apiUrl}/auth/login`;
  //   return this.http.connect<UserData>(CoreApiMethodType.post, url, body);
  // }
}
