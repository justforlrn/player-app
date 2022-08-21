import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { TDSModalRef } from 'tds-ui/modal';
import { UserMinimized } from '../../users/models/users/user-minimized.model';
import { UserService } from '../../users/services/user.service';
import { CreateGroup } from '../models/create-group.model';
import { GroupDisplayDashboardService } from '../services/group-display-dashboard.service';

@Component({
  selector: 'app-new-group',
  templateUrl: './new-group.component.html',
  providers: [UserService],
})
export class NewGroupComponent {
  form!: FormGroup;
  userList: any[];
  constructor(
    private modal: TDSModalRef,
    private formBuilder: FormBuilder,
    private _userService: UserService
  ) {}
  cancel() {
    this.modal.destroy(null);
  }

  createForm(): void {
    this.form = this.formBuilder.group({
      name: [],
      emails: [],
      isPublic: [true],
    });
  }

  getUserMinimizedList() {
    this._userService.getUserMinimizedList().subscribe((res: UserMinimized[]) => {
      this.userList = res.map(e => {
        return { email: e.email, combineName: `${e.name} - ${e.email}` };
      });
      debugger;
    });
  }

  ngOnInit() {
    this.getUserMinimizedList();
    this.createForm();
  }

  save() {
    this.onSubmit();
  }
  onSubmit() {
    if (!this.form.invalid) {
      console.log(this.form.value);
      debugger;
      this.modal.destroy(this.form.value);
    }
  }
}
