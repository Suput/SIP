import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DocsService } from '../../docs.service';
import { EventDocumentView } from 'src/app/api/models';

@Component({
  selector: 'app-events-detail',
  templateUrl: './events-detail.component.html',
  styleUrls: ['./events-detail.component.css']
})
export class EventsDetailComponent implements OnInit {

  public doc: EventDocumentView;
  constructor(private actRouter: ActivatedRoute, private docsService: DocsService) { }

  ngOnInit() {
    this.actRouter.paramMap.subscribe(async params => {
      const docs: EventDocumentView[] = await this.docsService.GetEventDocs(false);
      this.doc = docs.find(x => x.id === +params.get('docId'));
      console.log(this.doc);
    });
  }

}
