import {Component, Input} from '@angular/core';
import {IProduct} from "../../models/product";

@Component({
  selector: 'app-product-link',
  templateUrl: './product-link.component.html',
  styleUrls: ['./product-link.component.scss']
})
export class ProductLinkComponent {
  @Input() product!: IProduct;
}
