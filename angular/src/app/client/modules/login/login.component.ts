import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppLabels } from 'src/app/shared/app.constants';
import { HttpCustomSharedService } from 'src/app/shared/http-custom.shared.service';
import { SharedService } from 'src/app/shared/shared.service';
import { environment } from 'src/environments/environment';
import { TDSMessageService } from 'tds-ui/message';
import { LoginSuccessResponse } from './login.model';

@Component({
  selector: 'app-client-login',
  templateUrl: './login.component.html',
})
export class ClientLoginComponent {
  appLabels!: AppLabels;
  loginUrl = `${environment.apiUrl}/api/auths/sign-in`;
  form!: FormGroup;
  constructor(
    private _sharedService: SharedService,
    private _httpCustomSharedService: HttpCustomSharedService,
    private _fb: FormBuilder,
    private _msg: TDSMessageService
  ) {
    this.appLabels = this._sharedService.language;
    this.form = this._fb.group({
      usernameOrEmail: [null, Validators.required],
      password: [null, Validators.required],
    });
  }
  ngOnInit() {}
  login() {
    if (this.form.valid) {
      this._httpCustomSharedService
        .post<LoginSuccessResponse>(this.loginUrl, {
          usernameOrEmail: this.form.value.usernameOrEmail,
          password: this.form.value.password,
        })
        .subscribe((res) => {
          this._msg.success(this.appLabels.constants.LoginSuccessMessage);
          localStorage.setItem('userData', JSON.stringify(res));
        });
    }
  }
}
