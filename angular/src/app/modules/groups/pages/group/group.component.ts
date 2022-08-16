import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TDSModalService } from 'tds-ui/modal';
import { NewGroupOrderComponent } from '../../components/new-group-order.component';
import { Group } from '../../models/group.model';
import { GroupService } from '../../services/group.service';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  providers: [GroupService]
})
export class GroupListComponent {
  empty = false;
  orderGroupList: Group[] = [];
  constructor(private _groupService: GroupService, private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private modalService: TDSModalService) {}
    groupId: string;
    ngOnInit(): void {
      this.groupId = this._activatedRoute.snapshot.params["id"]
      this.getList();
    }
    
  getList(): void {
    this._groupService.getOrderGroupList().subscribe((res: Group[]) => {
      this.orderGroupList = res;
    })
  }

  onClickItem(id: string) {
    this._router.navigate([this._router.url, id])
  }

  onClickCreateItem() {
    const modal = this.modalService.create({
      title: 'Chọn quán order chung',
      content: NewGroupOrderComponent,
      size: 'sm',
      componentParams: {
        groupId: this.groupId
    }
    });
  }
}