import { Injectable } from '@angular/core';
import {IProduct} from "../../shared/models/product";
import {Observable, Subject} from "rxjs";
import {IBrand} from "../../shared/models/brand";
import {IProductType} from "../../shared/models/productType";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Pagination} from "../../shared/models/Pagination";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  private baseUrl = 'http://localhost:5000/'
  private productsSource = new Subject<IProduct[]>;
  private productTypesSource = new Subject<IProductType[]>;
  private brandsSource = new Subject<IBrand[]>;

  constructor(private httpClient: HttpClient) {
  }

  fetchProducts(pagination: Pagination, sortings?: string[], productTypeName?: string, brandName?: string){
    let httpParams = new HttpParams();
    httpParams = httpParams.append('offset', pagination.getOffset());
    httpParams = httpParams.append('limit', pagination.getLimit());

    if (sortings) {
      sortings.forEach((sorting) => {
        httpParams = httpParams.append('sortings', sorting);
      });
    }

    if (productTypeName){
      httpParams = httpParams.append('productTypeName', productTypeName);
    }

    if (brandName){
      httpParams = httpParams.append('brandName', brandName);
    }

    this.httpClient.get<IProduct[]>(this.baseUrl + 'api/products', {params: httpParams})
      .subscribe(value => {
        this.productsSource.next(value);
      });
  }

  fetchProductTypes(){
    this.httpClient.get<IProductType[]>(this.baseUrl + 'api/product-types')
      .subscribe(value => {
        this.productTypesSource.next(value);
      });
  }

  fetchBrands(){
    return this.httpClient.get<IBrand[]>(this.baseUrl + 'api/brands')
      .subscribe(value => {
        this.brandsSource.next(value);
      });
  }

  getProductsSource(): Observable<IProduct[]>{
    return this.productsSource;
  }

  getProductTypesSource(): Observable<IProductType[]>{
    return this.productTypesSource;
  }

  getBrandsSource(): Observable<IBrand[]>{
    return this.brandsSource;
  }
}
