import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../api/services';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  private registering: boolean;
  constructor(private authService: AuthenticationService) { }

  ngOnInit() {
    this.registering = false;
  }

  ToggleRegister() {
    this.registering = !this.registering;
  }
}
