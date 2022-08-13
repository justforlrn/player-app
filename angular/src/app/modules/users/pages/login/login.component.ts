import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CoreCommonService } from 'src/app/core';
import { TDSMessageService } from 'tds-ui/message';
import { LoginDto } from '../../models/login/login.model';
import { UserData } from '../../models/users/user-data.model';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './login.component.html',
  providers: [UserService],
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  model!: LoginDto;
  constructor(
    private _fb: FormBuilder,
    private _userService: UserService,
    private _message: TDSMessageService,
    private _router: Router,
    private _coreCommonService: CoreCommonService
  ) {}

  createForm() {
    this.form = this._fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.createForm();
  }

  private prepareModel(): LoginDto {
    const formModel = this.form.value;
    const model: LoginDto = {
      email: formModel.email as string,
      password: formModel.password as string,
    };
    return model;
  }

  onSubmit(): void {
    this.model = this.prepareModel();
    this._userService.login(this.model).subscribe(
      (res: UserData) => {
        this._coreCommonService.setUserData(res);
        this._message.success(`Hello ${res.name}`);
      },
      (err: any) => {
        this._message.error(`Lỗi`);
      }
    );
  }
}
