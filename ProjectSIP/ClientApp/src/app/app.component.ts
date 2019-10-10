import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ProjectSIP';
  public isAuthorized: boolean;
  constructor() {
    this.isAuthorized = false;
  }
}
