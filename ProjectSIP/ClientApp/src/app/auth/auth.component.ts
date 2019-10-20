import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../api/services';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {
  authForm: FormGroup;

  constructor(private authService: AuthenticationService, private formBuilder: FormBuilder,
              private router: Router) {
                this.authForm = formBuilder.group({
                  email: '',
                  password: ''
                });
               }

  ngOnInit() { }

  async onSubmit(loginData) {
    try {
      const response = await this.authService.apiAuthLoginPost$Json$Response({body: loginData}).toPromise();
      localStorage.setItem('token', response.body.accessToken);
      localStorage.setItem('currentUserId', response.body.user.id.toString());
      this.router.navigate(['main']);
    } catch (ex) {
      console.error(ex);
    }
  }
}
