import { Component, OnInit } from '@angular/core';
import { DataSourceService } from '../data-source.service';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {

  products: any[] = [];
  loaded: boolean = false;

  constructor(private ds: DataSourceService) { }

  ngOnInit() {
    this.ds.getAllProducts().subscribe(p => { this.products = p; this.loaded = true; });
  }
}
