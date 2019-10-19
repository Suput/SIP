import { Component, OnInit } from '@angular/core';
import { ApiInterceptor } from '../services/httpBearer/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-conflict',
  templateUrl: './conflict.component.html',
  styleUrls: ['./conflict.component.css']
})
export class ConflictComponent implements OnInit {
  private error: string;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.error = params.get('error');
    });
  }

}
