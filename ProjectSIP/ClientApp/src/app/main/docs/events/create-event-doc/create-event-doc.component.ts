import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { AccountService } from 'src/app/api/services';
import { UserView, CreateUserEventDocument } from 'src/app/api/models';

@Component({
  selector: 'app-create-event-doc',
  templateUrl: './create-event-doc.component.html',
  styleUrls: ['./create-event-doc.component.css']
})
export class CreateEventDocComponent implements OnInit {
  public Name: string;
  createForm: FormGroup;
  allUsers: UserView[];
  constructor(private formBuilder: FormBuilder, private accountService: AccountService) {
    this.createForm = formBuilder.group({
      divisionName: '',
      eventStart: '',
      fullname: '',
      lawNumber: '',
      mainAccountantId: -1,
      name: '',
      necessariesFromDivision: '',
      organizationName: '',
      organizatorId: -1,
      spendMoney: '',
      supervisorId: -1,
      supervisorSigniture: '',
      targets: '',
      createUserEventDocuments: Array<CreateUserEventDocument>()
    });
  }

  async ngOnInit() {
    this.allUsers = await this.accountService.apiAccountAllusersGet().toPromise();
  }

  onSubmit(createData) {
    console.log(createData.mainAccountantId);
  }
}
