import { Injectable } from '@angular/core';
import { DatePipe } from '@angular/common';
import { EventDocumentService } from 'src/app/api/services';
import { EventDocumentView } from 'src/app/api/models';

@Injectable({
  providedIn: 'root'
})
export class DocsService {

  private EventDocs: EventDocumentView[];
  constructor(private eventDocsService: EventDocumentService, private datePipe: DatePipe) { }

  async GetEventDocs(refresh: boolean): Promise<EventDocumentView[]> {
    if (refresh || (this.EventDocs !== undefined && this.EventDocs.length === 0)) {
      this.EventDocs = await this.eventDocsService.apiEventdocsGet().toPromise();
      this.EventDocs.forEach(doc => {
        doc.eventStart = this.datePipe.transform(doc.eventStart, 'dd.MM.yyyy HH:mm');
      });
      return this.EventDocs;
    } else {
      return this.EventDocs;
    }
  }
}
