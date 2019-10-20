import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DocumentView } from 'src/app/api/models';
import { DocsService } from '../docs/docs.service';

@Component({
  selector: 'app-docs-detail',
  templateUrl: './docs-detail.component.html',
  styleUrls: ['./docs-detail.component.css']
})
export class DocsDetailComponent implements OnInit {

  private doc: DocumentView;
  constructor(private router: ActivatedRoute, private docsService: DocsService) { }

  ngOnInit() {
    this.router.paramMap.subscribe(params => {
      this.doc = this.docsService.GetDocuments(false)[+params.get('doc')];
    });
  }

}
