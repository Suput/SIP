import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/api/services';
import { UserRoleView } from 'src/app/api/models';

@Component({
  selector: 'app-manage-users',
  templateUrl: './manage-users.component.html',
  styleUrls: ['./manage-users.component.css']
})
export class ManageUsersComponent implements OnInit {
  public Users: UserRoleView[];
  constructor(private accountService: AccountService) { }

  async ngOnInit() {
    this.Users = await this.accountService.apiAccountUsersGet().toPromise();
  }

}
