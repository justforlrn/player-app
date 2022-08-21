import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TDSMessageService } from 'tds-ui/message';
import { TDSModalService } from 'tds-ui/modal';
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
  constructor(
    private _groupDisplayDashboardService: GroupDisplayDashboardService,
    private _router: Router,
    private modalService: TDSModalService,
    private _messageService: TDSMessageService
  ) {}
  ngOnInit(): void {
    this.getList();
  }
  onClickItem(id: string) {
    this._router.navigate([this._router.url, id]);
  }
  getList(): void {
    this._groupDisplayDashboardService.getJoinedGroupList().subscribe((res: Group[]) => {
      this.joinedGroupList = res;
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
        isPublic: false,
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
