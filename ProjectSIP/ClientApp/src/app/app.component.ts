import { Component, OnInit } from '@angular/core';
import { UserService } from './services/httpBearer/user.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'ProjectSIP';
  constructor(private userService: UserService, private router: Router, private location: Location) { }

  async ngOnInit() {
    console.log('Is user authorizated? - ' + this.userService.IsAuthorizated());
    if (!this.userService.IsAuthorizated()) {
      this.router.navigate(['auth']);
    }
    if (this.location.path() === '') {
      this.router.navigate(['main']);
    }
  }
}
