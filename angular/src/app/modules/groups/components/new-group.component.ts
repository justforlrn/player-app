import { Component, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { TDSModalRef } from 'tds-ui/modal';

@Component({
  selector: 'app-new-group',
  templateUrl: './new-group.component.html',
})
export class NewGroupComponent {  
  public statusList: any[] = [
    {
      id: 1,
      name: 'Công khai',
    },    
    {
      id: 2,
      name: 'Riêng tư',
    }
  ]
  
  public selected = { id: 1, name: 'Công khai' };
  form!: FormGroup;
  constructor(private modal: TDSModalRef,private formBuilder: FormBuilder) {}
  cancel() {
    this.modal.destroy(null);
   
}

createForm(): void {
  this.form = this.formBuilder.group({
    name: [],
    status: [],
    //secretKey: []
    //fileList: [],
  });
}

ngOnInit() {
  this.createForm()
}

save() {
    this.onSubmit();
}
onSubmit() {
  if (!this.form.invalid) {
      this.modal.destroy(this.form.value);
  }
}
}
