import {Component, Input} from '@angular/core';
import {BasketService} from "../../shared/services/basket.service";
import {Observable} from "rxjs";
import {IBasketTotals} from "./basket-totals";

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss']
})
export class OrderTotalsComponent {
  @Input() basketTotals: IBasketTotals = {shipping: 10, subtotal: 10, total: 10};

  constructor(private basketService: BasketService) {

  }
}
