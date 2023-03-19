import { Injectable } from '@angular/core';
import {IProduct} from "../shared/models/product";
import {Observable} from "rxjs";
import {ProductMocker} from "./mockers/product-mocker";
import {IBrand} from "../shared/models/brand";
import {IProductType} from "../shared/models/productType";
import {BrandMocker} from "./mockers/brand-mocker";
import {ProductTypeMocker} from "./mockers/productType-mocker";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'http://localhost:5000/'

  constructor(private productMocker: ProductMocker, private brandMocker: BrandMocker, private productTypeMocker: ProductTypeMocker,
              private httpClient: HttpClient) {
  }

  getProducts(): Observable<IProduct[]>{
    return new Observable<IProduct[]>(
      subscriber => {
        subscriber.next(this.productMocker.getMockProducts())
      }
    )
  }

  getProductTypes(): Observable<IProductType[]>{
    return this.httpClient.get<IProductType[]>(this.baseUrl + 'api/product-types');
  }

  getBrands(): Observable<IBrand[]>{
    return this.httpClient.get<IBrand[]>(this.baseUrl + 'api/brands');
  }
}
