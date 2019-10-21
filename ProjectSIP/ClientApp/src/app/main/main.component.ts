import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/httpBearer/user.service';
import { AccountService } from '../api/services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  public isAdmin: boolean;
  public readonly AdminRole = 'admin';
  public Email: string;
  public myRoles: string[];
  constructor(private userService: UserService, private accountService: AccountService, private router: Router) { }

  async ngOnInit() {
    this.myRoles  = await this.accountService.apiAccountMyrolesGet().toPromise();
    if (this.myRoles.indexOf(this.AdminRole) !== -1) {
      this.isAdmin = true;
      // this.router.navigate(['main/admin']);
    } else {
      // this.router.navigate(['main/docs']);
    }
    const user = await this.userService.GetUserModel();
    this.Email = user.email.substring(0, user.email.indexOf('@'));
  }

}
