import {Component, Input} from '@angular/core';
import {IReadonlyBasketItem} from "../../shared/models/basket-item";
import {LinkProviderService} from "../../shared/services/link-provider.service";


@Component({
  selector: 'app-basket-summary',
  templateUrl: './basket-summary.component.html',
  styleUrls: ['./basket-summary.component.scss']
})
export class BasketSummaryComponent {
  @Input() basketItems?: ReadonlyArray<IReadonlyBasketItem>;

  constructor(public linkProvider: LinkProviderService) { }
}
