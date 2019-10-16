import { Component, OnInit, OnChanges } from '@angular/core';
import { UserService } from './services/httpBearer/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'ProjectSIP';
  public isAuthorized: boolean;
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    if (this.userService.IsAuthorizated()) {
      this.router.navigate(['main']);
    } else {
      this.router.navigate(['auth']);
    }
  }
}
