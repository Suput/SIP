import { Component, OnInit, ComponentFactoryResolver } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DocumentView } from 'src/app/api/models';
import { DocsService } from '../docs/docs.service';
import { DocumentService } from 'src/app/api/services';

@Component({
  selector: 'app-docs-detail',
  templateUrl: './docs-detail.component.html',
  styleUrls: ['./docs-detail.component.css']
})
export class DocsDetailComponent implements OnInit {

  public doc: DocumentView;
  constructor(private router: ActivatedRoute, private docsService: DocsService) { }

  ngOnInit() {
    this.router.paramMap.subscribe(async params => {
      const docs: DocumentView[] = await this.docsService.GetDocuments(false);
      this.doc = docs.find( x => x.id === +params.get('doc'));
      // this.doc = await this.docsService.GetDocuments(false)[+params.get('doc')];
      console.log(this.doc);
    });
  }

}
