import { Component, OnInit } from '@angular/core';
import { EventDocumentView } from 'src/app/api/models';
import { Router } from '@angular/router';
import { DocsService } from '../docs.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {
  public EventDocs: EventDocumentView[];
  constructor(private docsService: DocsService, private router: Router) { }

  async ngOnInit() {
    this.EventDocs = await this.docsService.GetEventDocs(true);
  }

  LoadDetail(docId: number) {
    console.log(docId);
    this.router.navigate(['main/docs/events', docId]);
  }

  CreateEventDocument() {
    console.log('Create event document');
    this.router.navigate(['main/docs/events/create']);
  }
}
