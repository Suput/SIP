import { Component, OnInit } from '@angular/core';
import { DocumentView } from '../../api/models';
import { DocsService } from './docs.service';

@Component({
  selector: 'app-docs',
  templateUrl: './docs.component.html',
  styleUrls: ['./docs.component.css']
})
export class DocsComponent implements OnInit {

  private docs: DocumentView[];
  constructor(private docstService: DocsService) { }

  async ngOnInit() {
    this.docs = await this.docstService.GetDocuments(true);
  }

  LoadDetail(doc: number) {
    console.log(doc);
  }
}
