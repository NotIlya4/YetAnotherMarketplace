import {Component, OnInit} from '@angular/core';
import {IProduct} from "../../shared/models/product";
import {ShopService} from "../shop-service/shop.service";
import {ActivatedRoute} from "@angular/router";
import {faMinusCircle} from "@fortawesome/free-solid-svg-icons/faMinusCircle";
import {faPlusCircle} from "@fortawesome/free-solid-svg-icons/faPlusCircle";
import {BreadcrumbService} from "xng-breadcrumb";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit{
  minusCircleIcon = faMinusCircle;
  plusCircleIcon = faPlusCircle;

  product: IProduct =  {
    id: '',
    name: '',
    description: '',
    price: 0,
    pictureUrl: '',
    productType: '',
    productBrand: ''
  };

  constructor(private shopService: ShopService, private activatedRoot: ActivatedRoute, private breadcrumbService: BreadcrumbService) {
    shopService.getProductSource().subscribe(value => {
      this.product = value;
      this.breadcrumbService.set('shop/:id', value.name);
    })
  }

  ngOnInit() {
    const id: string | null = this.activatedRoot.snapshot.paramMap.get('id');
    if (id){
      this.shopService.fetchProduct(id);
    }
  }
}
