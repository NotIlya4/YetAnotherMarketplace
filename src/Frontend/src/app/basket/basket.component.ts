import { Component } from '@angular/core';
import {BasketService} from "../shared/services/basket.service";
import {IBasketItem, IReadonlyBasketItem} from "../shared/models/basket-item";
import {IBasketTotals} from "./order-totals/basket-totals";

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent {
  basketItems?: ReadonlyArray<IReadonlyBasketItem>
  basketTotals?: IBasketTotals;

  constructor(private basketService: BasketService) {
    basketService
      .basketItems$
      .subscribe((value) => this.basketItems = value);
    basketService
      .basketTotals$
      .subscribe(value => this.basketTotals = value);
  }
}
