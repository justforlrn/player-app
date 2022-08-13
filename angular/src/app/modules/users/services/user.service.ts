import { Injectable } from '@angular/core';
import { CoreApiMethodType, CoreCommonService } from 'src/app/core';
import { environment } from 'src/environments/environment';
import { LoginDto } from '../models/login/login.model';
import { UserData } from '../models/users/user-data.model';

@Injectable()
export class UserService {
  private apiUrl = environment.apis.default.url;
  constructor(private http: CoreCommonService) {}

  login(body: LoginDto) {
    const url = `${this.apiUrl}/users/login`;
    return this.http.connect<UserData>(CoreApiMethodType.post, url, body);
  }
}
