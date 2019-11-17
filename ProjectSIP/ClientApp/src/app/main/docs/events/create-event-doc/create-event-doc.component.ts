import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, NgSelectOption } from '@angular/forms';
import { AccountService, EventDocumentService } from 'src/app/api/services';
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
  Select1: CreateUserEventDocument;
  Select2: CreateUserEventDocument;
  Select3: CreateUserEventDocument;
  Select4: CreateUserEventDocument;
  isCreated: boolean;
  constructor(private formBuilder: FormBuilder, private accountService: AccountService, private eventDocService: EventDocumentService) {
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
      createUserEventDocuments: formBuilder.array([])
      // new Array<CreateUserEventDocument>()
    });
  }

  async ngOnInit() {
    this.allUsers = await this.accountService.apiAccountAllusersGet().toPromise();
  }

  async onSubmit(createData) {
    // console.log('onSubmit');
    createData.createUserEventDocuments = this.SelectIntoCreateData();
    // console.log(createData.createUserEventDocuments);
    createData.mainAccountantId = +createData.mainAccountantId;
    createData.organizatorId = +createData.organizatorId;
    createData.supervisorId = +createData.supervisorId;
    createData.organizationName = 'ООО Гостиница "ЮКИЁ"';
    console.log(createData);
    try {
      const request = await this.eventDocService.apiEventdocsPost$Json$Response({body: createData}).toPromise();
      if (request.status === 200) {
        this.ShowInfoMessage();
      }
    } catch (ex) {
      console.log(ex);
    }
  }

  SelectIntoCreateData(): Array<CreateUserEventDocument> {
    const arr: Array<CreateUserEventDocument> = new Array<CreateUserEventDocument>();
    if (this.Select1 !== undefined) {
      if (this.Select1.userId.toString() !== '-1') {
        arr.push(this.Select1);
      }
    }
    if (this.Select2 !== undefined) {
      if (this.Select2.userId.toString() !== '-1') {
        arr.push(this.Select2);
      }
    }
    if (this.Select3 !== undefined) {
      if (this.Select3.userId.toString() !== '-1') {
        arr.push(this.Select3);
      }
    }
    if (this.Select4 !== undefined) {
      if (this.Select4.userId.toString() !== '-1') {
        arr.push(this.Select4);
      }
    }
    console.log(arr);
    arr.forEach(elem => {
      elem.userId = +elem.userId;
    });
    return arr;
  }

  ShowInfoMessage() {
    this.isCreated = true;
    setTimeout(x => this.isCreated = false, 4500);
  }

  select1(event): void {
    if (this.Select1 === undefined) {
      this.Select1 = {
        userId: event.target.value
      };
    } else {
      this.Select1.userId = event.target.value;
    }
    // this.createForm.value.createUserEventDocuments.push(temp);
    console.log(this.Select1);
  }
  select2(event): void {
    if (this.Select2 === undefined) {
      this.Select2 = {
        userId: event.target.value
      };
    } else {
      this.Select2.userId = event.target.value;
    }
    // this.createForm.value.createUserEventDocuments.push(temp);
    console.log(this.Select2);
  }
  select3(event): void {
    if (this.Select3 === undefined) {
      this.Select3 = {
        userId: event.target.value
      };
    } else {
      this.Select3.userId = event.target.value;
    }
    // this.createForm.value.createUserEventDocuments.push(temp);
    console.log(this.Select3);
  }
  select4(event): void {
    if (this.Select4 === undefined) {
      this.Select4 = {
        userId: event.target.value
      };
    } else {
      this.Select4.userId = event.target.value;
    }
    // this.createForm.value.createUserEventDocuments.push(temp);
    console.log(this.Select4);
  }
}
