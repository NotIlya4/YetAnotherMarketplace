import { Component } from '@angular/core';
import {BasketService} from "../shared/services/basket.service";
import {IBasketItem, IReadonlyBasketItem} from "../shared/models/basket-item";

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent {
  basketItems: ReadonlyArray<IReadonlyBasketItem> = []

  constructor(private basketService: BasketService) {
    basketService
      .basketItems$
      .subscribe((value) => {this.basketItems = value});
  }

  onMinusPressed($event: IBasketItem) {
    this.basketService.decreaseProduct($event.product);
  }


  onPlusPressed($event: IBasketItem) {
    this.basketService.increaseProduct($event.product);
  }

  onRemovePressed($event: IBasketItem) {
    this.basketService.deleteProduct($event.product);
  }
}
