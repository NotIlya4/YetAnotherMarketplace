import { Injectable } from '@angular/core';
import {IProduct} from "../shared/models/product";
import {Observable} from "rxjs";
import {ProductMocker} from "./mockers/product-mocker";
import {IBrand} from "../shared/models/brand";
import {IProductType} from "../shared/models/productType";
import {BrandMocker} from "./mockers/brand-mocker";
import {ProductTypeMocker} from "./mockers/productType-mocker";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  constructor(private productMocker: ProductMocker, private brandMocker: BrandMocker, private productTypeMocker: ProductTypeMocker) {
  }

  getProducts(): Observable<IProduct[]>{
    return new Observable<IProduct[]>(
      subscriber => {
        subscriber.next(this.productMocker.getMockProducts())
      }
    )
  }

  getProductTypes(): Observable<IProductType[]>{
    return new Observable<IProductType[]>(
      subscriber => {
        subscriber.next(this.productTypeMocker.getProductTypes())
      }
    )
  }

  getBrands(): Observable<IBrand[]>{
    return new Observable<IBrand[]>(
      subscriber => {
        subscriber.next(this.brandMocker.getBrands())
      }
    )
  }
}
