import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/httpBearer/user.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  public isAdmin: boolean;
  public Email: string;
  constructor(private userService: UserService) { }

  async ngOnInit() {
    this.isAdmin = true;
    const user = await this.userService.GetUserModel();
    this.Email = user.email.substring(0, user.email.indexOf('@'));
  }

}
