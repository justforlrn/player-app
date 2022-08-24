import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TDSMessageService } from 'tds-ui/message';
import { TDSModalService } from 'tds-ui/modal';
import { EditGroupComponent } from '../../components/edit-group.component';
import { NewGroupComponent } from '../../components/new-group.component';
import { CreateGroup } from '../../models/create-group.model';
import { Group } from '../../models/group.model';
import { GroupDisplayDashboardService } from '../../services/group-display-dashboard.service';

@Component({
  selector: 'app-group-display-dashboard',
  templateUrl: './group-display-dashboard.component.html',
  providers: [GroupDisplayDashboardService],
})
export class GroupDisplayDashboardComponent {
  //empty = false;
  joinedGroupList: Group[] = [];
  isLoading = false;
  constructor(
    private _groupDisplayDashboardService: GroupDisplayDashboardService,
    private _router: Router,
    private modalService: TDSModalService,
    private _messageService: TDSMessageService
  ) {}
  ngOnInit(): void {
    this.getList();
  }
  openSetting(e: any) {
    e.preventDefault();
    e.stopImmediatePropagation();
  }

  editGroup(groupId: string) {
    const modal = this.modalService.create({
      title: 'Chỉnh sửa nhóm',
      content: EditGroupComponent,
      size: 'sm',
      componentParams: {
        groupInfo: this.joinedGroupList.filter(e => e.id == groupId)[0],
      },
    });

    modal.afterClose.subscribe(result => {});
  }

  deleteGroup(groupId: string) {
    this._groupDisplayDashboardService.deleteGroup(groupId).subscribe(
      () => {
        this._messageService.success('Xóa group thành công');
      },
      (err: any) => {
        console.log(err);
        this._messageService.error(`Lỗi: ${err.error.error.message}`);
      }
    );
  }

  onClickItem(id: string) {
    this._router.navigate([this._router.url, id]);
  }
  getList(): void {
    this.isLoading = true;
    this._groupDisplayDashboardService.getJoinedGroupList().subscribe((res: Group[]) => {
      this.joinedGroupList = res;
      this.isLoading = false;
    });
  }
  onClickCreateItem() {
    const modal = this.modalService.create({
      title: 'Thêm nhóm mới',
      content: NewGroupComponent,
      size: 'sm',
    });

    modal.afterClose.subscribe(result => {
      var subData: CreateGroup = {
        name: result.name,
        description: '',
        isPublic: result.isPublic,
        emails: result.emails,
      };
      debugger;
      this._groupDisplayDashboardService.createGroup(subData).subscribe(() => {
        this._messageService.success('Tạo group thành công');
      });
      // this.getCustomer();
    });
  }
}
