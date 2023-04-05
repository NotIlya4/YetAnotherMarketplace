import {Component, EventEmitter, Input, Output} from '@angular/core';
import {BasketService} from "../../shared/services/basket.service";
import {IBasketItem, IReadonlyBasketItem} from "../../shared/models/basket-item";
import {faCircleMinus} from "@fortawesome/free-solid-svg-icons";
import {faCirclePlus} from "@fortawesome/free-solid-svg-icons";
import {faTrash} from "@fortawesome/free-solid-svg-icons";
import {IconDefinition} from "@fortawesome/free-regular-svg-icons";


@Component({
  selector: 'app-basket-summary',
  templateUrl: './basket-summary.component.html',
  styleUrls: ['./basket-summary.component.scss']
})
export class BasketSummaryComponent {
  @Output() minusPressed: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() plusPressed: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() removePressed: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Input() basketItems!: ReadonlyArray<IReadonlyBasketItem>;

  plusCircleIcon: IconDefinition = faCirclePlus;
  minusCircleIcon: IconDefinition = faCircleMinus;
  trashIcon: IconDefinition = faTrash;


  constructor(private basketService: BasketService) { }

  onMinusPressed(item: IBasketItem){
    this.minusPressed.emit(item);
  }

  onPlusPressed(item: IBasketItem){
    this.plusPressed.emit(item);
  }

  onRemovePressed(item: IBasketItem){
    this.removePressed.emit(item);
  }
}
