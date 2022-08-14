import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CoreApiMethodType, CoreCommonService } from 'src/app/core';
import { environment } from 'src/environments/environment';
import { UserData } from '../../users/models/users/user-data.model';
import { Group } from '../models/group.model';

@Injectable()
export class GroupService {
  private apiUrl = environment.apiUrl;
  private currentUser!: UserData;
  constructor(private _coreCommonService: CoreCommonService) {
    this.currentUser = this._coreCommonService.getUserData();
  }
  public getOrderGroupList(): Observable<Group[]> {
    const listGroup: Group[] = [];
    var g1: Group = {
      Id: "4",
      Name: 'Hồ Đắc Di',
      Members: [
        this.currentUser
      ]
    }
    var g2: Group = {
      Id: "2",
      Name: 'Cơm Gà',
      Members: [
        this.currentUser
      ]
    }
    listGroup.push(g1)
    listGroup.push(g2)
    var ob = new Observable<Group[]>((obs) => {
      obs.next(listGroup);
    });
    return ob;
  }
  // login(body: LoginDto) {
  //   const url = `${this.apiUrl}/auth/login`;
  //   return this.http.connect<UserData>(CoreApiMethodType.post, url, body);
  // }
}
