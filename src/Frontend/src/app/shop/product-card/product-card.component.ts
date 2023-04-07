import {Component, Input} from '@angular/core';
import {IProduct} from "../../shared/models/product";
import {LinkProviderService} from "../../shared/services/link-provider.service";

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent {
  @Input() product!: IProduct;

  constructor(public linkProvider: LinkProviderService) {
  }
}
