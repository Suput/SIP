import { Component, OnInit } from '@angular/core';
import { UserService } from './services/httpBearer/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'ProjectSIP';
  public isAuthorized: boolean;
  constructor(private userService: UserService) { }

  ngOnInit() {
    this.isAuthorized = this.userService.IsAuthorizated();
    console.log('Is user authorized: ' + this.isAuthorized);
  }
}
