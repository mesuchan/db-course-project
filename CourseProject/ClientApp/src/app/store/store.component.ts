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

  search: string = "";
  color: string = "";
  sort: string = "";

  colors: string[] = [];

  get findedProducts(): any[] {
    return this.products.filter(product => {
      if (this.search == "")
        return true;
      return product["name"].includes(this.search);
    }).filter(product => {
      if (this.color == "")
        return true;
      return product["color"] == this.color;
      }).sort((a, b) => {
        if (this.sort == "")
          return Math.sign(a["id"] - b["id"]);

        if (this.sort == "Название (А -> Я)")
          return a["name"].localeCompare(b["name"]);

        if (this.sort == "Название (Я -> А)")
          return b["name"].localeCompare(a["name"]);

        if (this.sort == "Цена (по возрастанию)")
          return Math.sign(a["price"] - (b["price"]));

        if (this.sort == "Цена (по убыванию)")
          return Math.sign(b["price"] - (a["price"]));
    });
  }

  constructor(private ds: DataSourceService) { }

  ngOnInit() {
    this.ds.getAllProducts().subscribe(p => {
      this.products = p;
      this.loaded = true;

      this.colors = p.map(p => p["color"]);
      this.colors = this.colors.filter((c, i, self) => self.indexOf(c) === i);
      this.colors = this.colors.sort();
    });
  }
}
