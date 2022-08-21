import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CoreApiMethodType, CoreCommonService } from 'src/app/core';
import { environment } from 'src/environments/environment';
import { LoginDto } from '../models/login/login.model';
import { UserData } from '../models/users/user-data.model';
import { UserMinimized } from '../models/users/user-minimized.model';

@Injectable()
export class UserService {
  private apiUrl = environment.apis.default.url;
  constructor(private http: CoreCommonService) {}

  login(body: LoginDto) {
    const url = `${this.apiUrl}/users/login`;
    return this.http.connect<UserData>(CoreApiMethodType.post, url, body);
  }

  getUserMinimizedList(): Observable<UserMinimized[]> {
    const url = `${this.apiUrl}/users/get-user-minimized-list`;
    return this.http.connect<UserMinimized[]>(CoreApiMethodType.get, url, null);
  }
}
