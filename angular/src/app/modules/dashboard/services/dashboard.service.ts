import { Injectable } from '@angular/core';
import { CoreCommonService } from 'src/app/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class GroupDisplayDashboardService {
  private apiUrl = environment.apiUrl;
  constructor(private http: CoreCommonService) {}

  // login(body: LoginDto) {
  //   const url = `${this.apiUrl}/auth/login`;
  //   return this.http.connect<UserData>(CoreApiMethodType.post, url, body);
  // }
}
