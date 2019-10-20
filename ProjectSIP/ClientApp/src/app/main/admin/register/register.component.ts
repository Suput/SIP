import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AuthenticationService } from 'src/app/api/services';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  public isRegistered: boolean;

  public Lastemail: string;
  public Lastsecondname: string;
  public Lastfirstname: string;

  constructor(private authService: AuthenticationService, private formBuilder: FormBuilder) {
              this.registerForm = formBuilder.group({
                email: '',
                password: '',
                secondname: '',
                firstname: '',
                middlename: '',
                age: 0,
                position: ''
              });
            }

  ngOnInit() { }

  async onSubmit(registerData) {
    try {
      const response = await this.authService.apiAuthRegisterPost$Json$Response({body: registerData}).toPromise();
      if (response.status === 200) {
        console.log('New user was added');

        this.Lastemail = registerData.email;
        this.Lastsecondname = registerData.secondname;
        this.Lastfirstname = registerData.firstname;
        this.ShowInfoMessage();
      }
    } catch (ex) {
      console.error(ex);
    }
  }

  ShowInfoMessage() {
    this.isRegistered = true;
    setTimeout(x => this.isRegistered = false, 4500);
  }
}
