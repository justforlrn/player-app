import { Component, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TDSAutocompleteTriggerDirective, TDSAutocompleteComponent } from 'tds-ui/auto-complete';
import { TDSModalRef } from 'tds-ui/modal';
import { GroupService } from '../services/group.service';

@Component({
  selector: 'app-new-group-order',
  templateUrl: './new-group-order.component.html',
  providers: [GroupService],
})
export class NewGroupOrderComponent {
  @ViewChild(TDSAutocompleteTriggerDirective)
  autoComplete: TDSAutocompleteTriggerDirective;
  @ViewChild(TDSAutocompleteComponent)
  cmpAutoComplete: TDSAutocompleteComponent;

  //options: any[] = [];

  filteredOptions: any[] = [];
  selectedRestaurant: any;
  restaurantList: any[];
  constructor(
    private modal: TDSModalRef,
    private formBuilder: FormBuilder,
    private _groupService: GroupService,
    private _router: Router
  ) {}
  cancel() {
    this.modal.destroy(null);
  }

  onSearch(event: any) {
    console.log(event);
    this._groupService.onSearchRestaurant(event.value).subscribe(res => {
      console.log(res);
      this.filteredOptions = res;
    });
  }

  onClearAll(event: MouseEvent) {
    event.stopPropagation();
    this.selectedRestaurant = '';
  }

  // ngOnInit() {
  // }

  save() {
    this.onSubmit();
  }
  onSubmit() {
    if (typeof this.selectedRestaurant === 'string') {
      this._groupService.onGetRestaurant(this.selectedRestaurant).subscribe(res => {
        if (res?.items?.length) {
          this._router.navigateByUrl('dashboard');
        }
      });
    } else {
      this._router.navigateByUrl('group');
    }

    console.log(typeof this.selectedRestaurant);
    // if (!this.form.invalid) {
    //     this.modal.destroy(this.form.value);
    // }
  }
}
