import { Component, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TDSAutocompleteTriggerDirective, TDSAutocompleteComponent } from 'tds-ui/auto-complete';
import { TDSModalRef } from 'tds-ui/modal';
import { RestaurantMinimized } from '../../restaurants/models/restaurant-minimized.model';
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

  @Input() groupId!: string;
  restaurantMinimizedList: RestaurantMinimized[] = [];
  selectedRestaurant: any;
  restaurantList: any[];
  constructor(
    private modal: TDSModalRef,
    private formBuilder: FormBuilder,
    private _groupService: GroupService,
    private _router: Router
  ) {}

  checkTypeOf(data: any) {
    return typeof data;
  }

  cancel() {
    this.modal.destroy(null);
  }

  onSearch(event: any) {
    console.log(event);
    if (event.value != null && event.value != '') {
      this._groupService.onSearchRestaurant(event.value).subscribe((res: RestaurantMinimized[]) => {
        console.log(res);
        this.restaurantMinimizedList = res;
      });
    }
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
    const data = {
      groupId: this.groupId,
      restaurantId: this.selectedRestaurant.id,
    };
    this._groupService.createGroupOrder(data).subscribe(res => {
      debugger;
      console.log(res);
      this.modal.destroy(res.id);
    });
  }
}
