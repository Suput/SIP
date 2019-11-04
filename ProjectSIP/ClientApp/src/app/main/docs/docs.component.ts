import { Component, OnInit } from '@angular/core';
import { DocumentView } from '../../api/models';
import { DocsService } from './docs.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-docs',
  templateUrl: './docs.component.html',
  styleUrls: ['./docs.component.css']
})
export class DocsComponent implements OnInit {

  public docs: DocumentView[];
  constructor(private docsService: DocsService, private router: Router) { }

  async ngOnInit() {
    this.docs = await this.docsService.GetDocuments(true);
  }

  LoadDetail(doc: number) {
    console.log(doc);
    this.router.navigate(['main/docs', doc]);
  }
}
