import { Component, OnInit } from '@angular/core';
import { UserView } from 'src/app/api/models';
import { AccountService } from 'src/app/api/services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  public User: UserView;
  public Exited: boolean;
  constructor(private accountService: AccountService, private router: Router) { }

  async ngOnInit() {
    this.User = await this.accountService
      .apiAccountUserIdGet({userId: +localStorage.getItem('currentUserId')})
      .toPromise();
    console.log(this.User);
  }

  Exit() {
    localStorage.clear();
    this.ShowInfoMessage();
  }

  ShowInfoMessage() {
    this.Exited = true;
    setTimeout(x => {
        this.Exited = false;
        this.router.navigate(['auth']);
      }, 2000);
  }
}
