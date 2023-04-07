import {Directive, HostListener, Input} from '@angular/core';
import {IProduct} from "../models/product";
import {BasketService} from "../services/basket.service";

@Directive({
  selector: '[appRemoveProductsInBasket]'
})
export class RemoveProductsInBasketDirective {
  @Input() product!: IProduct;

  constructor(private basketService: BasketService) {
  }

  @HostListener('click')
  onClick() {
    this.basketService.deleteProduct(this.product);
  }
}
