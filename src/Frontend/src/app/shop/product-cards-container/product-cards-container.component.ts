import {Component, Input} from '@angular/core';
import {IProduct} from "../../shared/models/product";

@Component({
  selector: 'app-product-cards-container',
  templateUrl: './product-cards-container.component.html',
  styleUrls: ['./product-cards-container.component.scss']
})
export class ProductCardsContainerComponent {
  @Input() placeholderAmount = 6;
  @Input() products?: IProduct[];

  getArrayFromAmount(): number[]{
    return Array(this.placeholderAmount);
  }
}
