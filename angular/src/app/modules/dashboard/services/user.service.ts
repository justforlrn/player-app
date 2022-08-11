import { Injectable } from '@angular/core';
import { CoreApiMethodType } from '@core/enum';
import { CoreCommonService } from '@core/services';
import { environment } from 'src/environments/environment';
import { LoginDto } from '../models/login/login.model';
import { UserData } from '../models/users/user-data.model';

@Injectable()
export class UserService {
  private apiUrl = environment.apiUrl;
  constructor(private http: CoreCommonService) {}

  login(body: LoginDto) {
    const url = `${this.apiUrl}/auth/login`;
    return this.http.connect<UserData>(CoreApiMethodType.post, url, body);
  }
}
