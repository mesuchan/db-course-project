import { Component, OnInit } from '@angular/core';
import { DataSourceService } from '../data-source.service';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.css']
})
export class TitleComponent implements OnInit {

  constructor(private ds: DataSourceService) { }

  ngOnInit() {
  }

  get logged(): boolean {
    return this.ds.isLogged;
  }
}
