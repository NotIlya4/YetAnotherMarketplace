import {Component, OnInit} from '@angular/core';
import {IProduct} from "../../shared/models/product";
import {ActivatedRoute} from "@angular/router";
import {faMinusCircle} from "@fortawesome/free-solid-svg-icons/faMinusCircle";
import {faPlusCircle} from "@fortawesome/free-solid-svg-icons/faPlusCircle";
import {BreadcrumbService} from "xng-breadcrumb";
import {ProductsService} from "../../shared/services/products-service/products.service";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit{
  minusCircleIcon = faMinusCircle;
  plusCircleIcon = faPlusCircle;

  product?: IProduct;

  constructor(private productsService: ProductsService, private activatedRoot: ActivatedRoute, private breadcrumbService: BreadcrumbService) {

  }

  ngOnInit() {
    const id: string | null = this.activatedRoot.snapshot.paramMap.get('id');
    if (id){
      this.productsService.getProduct(id).subscribe(product => {
        this.product = product;
        this.breadcrumbService.set('shop/:id', product.name);
      })
    }
  }
}
