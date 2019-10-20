import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  public Exited: boolean;
  constructor() { }

  ngOnInit() {
  }

  Exit() {
    localStorage.clear();
    this.ShowInfoMessage();
  }

  ShowInfoMessage() {
    this.Exited = true;
    setTimeout(x => this.Exited = false, 4500);
  }
}
