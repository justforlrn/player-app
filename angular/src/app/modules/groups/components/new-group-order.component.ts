import { Component, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { TDSAutocompleteTriggerDirective, TDSAutocompleteComponent } from 'tds-ui/auto-complete';
import { TDSModalRef } from 'tds-ui/modal';

@Component({
  selector: 'app-new-group-order',
  templateUrl: './new-group-order.component.html',
})
export class NewGroupOrderComponent {
  @ViewChild(TDSAutocompleteTriggerDirective) 
        autoComplete: TDSAutocompleteTriggerDirective;
    @ViewChild(TDSAutocompleteComponent) 
        cmpAutoComplete: TDSAutocompleteComponent;
        
    options: any[] = [];
    
    filteredOptions: any[] = [];
  selectedRestaurant:any;
  restaurantList: any[]
  constructor(private modal: TDSModalRef,private formBuilder: FormBuilder) {}
  cancel() {
    this.modal.destroy(null);
   
}


onSearch(event: any) {
  console.log(event)
}

onClearAll(event: MouseEvent) {
  event.stopPropagation();
  this.selectedRestaurant = "";
  this.filteredOptions = this.options;
}

// ngOnInit() {
// }

save() {
    this.onSubmit();
}
onSubmit() {
  // if (!this.form.invalid) {
  //     this.modal.destroy(this.form.value);
  // }
}
}
