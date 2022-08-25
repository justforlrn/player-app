import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TDSMessageService } from 'tds-ui/message';
import { TDSModalService } from 'tds-ui/modal';
import { EditGroupOrderComponent } from '../../components/edit-group-order.component';
import { NewGroupOrderComponent } from '../../components/new-group-order.component';
import { GroupOrder } from '../../models/group-order.model';
import { Group } from '../../models/group.model';
import { GroupService } from '../../services/group.service';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  providers: [GroupService],
})
export class GroupListComponent {
  empty = false;
  orderGroupList: GroupOrder[] = [];
  isLoading = false;
  constructor(
    private _groupService: GroupService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private modalService: TDSModalService,
    private _messageService: TDSMessageService
  ) {}
  groupId: string;
  ngOnInit(): void {
    console.log(this._activatedRoute.snapshot);
    this.groupId = this._activatedRoute.snapshot.params['id'];
    this.getList();
  }

  getList(): void {
    this.isLoading = true;
    this._groupService.getGroupOrderList(this.groupId).subscribe((res: GroupOrder[]) => {
      this.orderGroupList = res;
      this.isLoading = false;
    });
  }

  editGroupOrder(id: string) {
    const modal = this.modalService.create({
      title: 'Chỉnh sửa nhóm',
      content: EditGroupOrderComponent,
      size: 'sm',
      componentParams: {
        groupOrderInfo: this.orderGroupList.filter(e => e.id == id)[0],
      },
    });

    modal.afterClose.subscribe(result => {});
  }

  deleteGroupOrder(id: string) {
    this._groupService.deleteGroupOrder(id).subscribe(
      () => {
        this._messageService.success('Xóa group thành công');
      },
      (err: any) => {
        console.log(err);
        this._messageService.error(`Lỗi: ${err.error.error.message}`);
      }
    );
  }

  onClickItem(item: GroupOrder) {
    this._router.navigate([this._router.url, item.id]);
  }

  onClickCreateItem() {
    const modal = this.modalService.create({
      title: 'Chọn quán order chung',
      content: NewGroupOrderComponent,
      size: 'lg',
      componentParams: {
        groupId: this.groupId,
      },
    });
    modal.afterClose.subscribe((groupOrderId: string) => {
      this._router.navigate([this._router.url, groupOrderId]);
    });
  }
}
