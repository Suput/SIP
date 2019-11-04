import { Injectable } from '@angular/core';
import { DocumentService } from 'src/app/api/services';
import { DocumentView } from 'src/app/api/models';
import { DatePipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class DocsService {

  private documents: DocumentView[];
  constructor(private documentService: DocumentService, private datePipe: DatePipe) { }

  async GetDocuments(refresh: boolean): Promise<DocumentView[]> {
    if (refresh || this.documents.length === 0) {
      this.documents = await this.documentService.apiDocsGet().toPromise();
      this.documents.forEach(doc => {
        doc.creationDate = this.datePipe.transform(doc.creationDate, 'dd.MM.yyyy HH:mm');
        doc.signtureDate = this.datePipe.transform(doc.signtureDate, 'dd.MM.yyyy HH:mm');
        doc.periodStart = this.datePipe.transform(doc.periodStart, 'dd.MM.yyyy HH:mm');
        doc.periodEnd = this.datePipe.transform(doc.periodEnd, 'dd.MM.yyyy HH:mm');
      });
      return this.documents;
    } else {
      return this.documents;
    }
  }
}
