import {Component, Input} from '@angular/core';
import {IProduct} from "../../shared/models/product";
import {faCartShopping} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-product-item[product]',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {
  @Input() product!: IProduct;
  shoppingCartIcon = faCartShopping;
}
