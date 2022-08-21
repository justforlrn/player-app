import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { TDSModalRef } from 'tds-ui/modal';
import { CreateGroup } from '../models/create-group.model';
import { GroupDisplayDashboardService } from '../services/group-display-dashboard.service';

@Component({
  selector: 'app-new-group',
  templateUrl: './new-group.component.html',
})
export class NewGroupComponent {
  form!: FormGroup;
  constructor(private modal: TDSModalRef, private formBuilder: FormBuilder) {}
  cancel() {
    this.modal.destroy(null);
  }

  createForm(): void {
    this.form = this.formBuilder.group({
      name: [],
      isPublic: [true],
    });
  }

  ngOnInit() {
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
