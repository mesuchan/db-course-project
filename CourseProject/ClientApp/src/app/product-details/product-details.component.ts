import { Component, OnInit, Input } from '@angular/core';
import { DataSourceService } from '../data-source.service';
import { ActivatedRoute } from '@angular/router';
import { isNullOrUndefined } from 'util';
import { CartService } from '../cart.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: any;
  size: number;

  recomended: any[] = [];

  constructor(private ds: DataSourceService, private route: ActivatedRoute, private c: CartService) { }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get("id");
    this.ds.getProduct(id).subscribe(p => { this.product = p; this.recomended.push(this.product); });
  }

  add(p: any) {
    if (!isNullOrUndefined(this.size))
    {
      alert("Этот товар размера " + this.size + " добавлен в корзину!");
      this.c.addToCart(p, this.size);
    }
    else
      alert("Вы не выбрали размер товара!");
  }
}

