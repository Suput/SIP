import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/api/services';
import { UserRoleView, UserView } from 'src/app/api/models';

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

  async DeleteUser(user: UserView) {
    // console.log(this.Users);
    console.log(`User id --- ${user.id}`);
    const isTrue = confirm(`Вы уверены что хотите удалить пользователя: ${user.secondname} ${user.firstname} ${user.middlename}?`);
    console.log(`Want to delete? --- ${isTrue}`);
    const index = this.Users.findIndex(x => x.user.id === user.id);
    console.log(`Index in array --- ${index}`);
    const response = await this.accountService.apiAccountUserIdDelete$Response({userId: user.id}).toPromise();
    if (response.status === 200) {
      if (index > -1) {
        this.Users.splice(index, 1);
      }
    } else {
      alert('Что-то пошло не так!');
    }
  }
}
