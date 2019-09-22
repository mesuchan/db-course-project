import { Injectable } from '@angular/core';
import { DataSourceService } from './data-source.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cart: any[] = [];
  num: number;

  constructor(private ds: DataSourceService) { }

  addToCart(product: any, size: number) {
    this.cart.push({ product, size });
  }

  get isEmpty() {
    return (this.cart.length == 0);
  }

  clearCart() {
    this.cart = [];
  }

  order() {
    let purchaseProducts = this.cart.map(c => ({ productId: c.product['productId'], size: c.size }));
    console.log(purchaseProducts);
    this.ds.order({ purchaseProducts }).subscribe(o => {
      alert("Заказ №" + o['purchaseId'] + " сформирован.");
    });
    this.cart = [];
  }
}
