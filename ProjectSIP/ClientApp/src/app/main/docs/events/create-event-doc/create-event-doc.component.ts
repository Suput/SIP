import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-event-doc',
  templateUrl: './create-event-doc.component.html',
  styleUrls: ['./create-event-doc.component.css']
})
export class CreateEventDocComponent implements OnInit {
  public Name: string;
  constructor() { }

  ngOnInit() {
  }

  OnInput() {
    const element = document.getElementById('eventName');
    this.Name = element.value;
  }

}
