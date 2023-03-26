import {Component, Input} from '@angular/core';
import {faCartShopping} from "@fortawesome/free-solid-svg-icons";
import {IProduct} from "../../shared/models/product";

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent {
  @Input() product!: IProduct;

  shoppingCartIcon = faCartShopping;
}
