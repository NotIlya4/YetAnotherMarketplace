import { Injectable } from '@angular/core';
import {Observable, Subject} from "rxjs";
import {IBrand} from "../../shared/models/brand";
import {IProductType} from "../../shared/models/productType";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Pagination} from "../../shared/models/Pagination";
import {IProductInfo} from "./products-info";
import {IProductFiltering} from "./product-filtering";

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  private baseUrl = 'http://localhost:5001/'
  private productsInfoSource = new Subject<IProductInfo>;
  private productTypesSource = new Subject<IProductType[]>;
  private brandsSource = new Subject<IBrand[]>;

  constructor(private httpClient: HttpClient) {
  }

  fetchProducts(pagination: Pagination, filtering: IProductFiltering, sortings: string[]){
    let httpParams = new HttpParams();
    httpParams = httpParams.append('offset', pagination.getOffset());
    httpParams = httpParams.append('limit', pagination.getLimit());

    if (sortings) {
      sortings.forEach((sorting) => {
        httpParams = httpParams.append('sortings', sorting);
      });
    }

    if (filtering.productTypeName){
      httpParams = httpParams.append('productTypeName', filtering.productTypeName);
    }

    if (filtering.brandName){
      httpParams = httpParams.append('brandName', filtering.brandName);
    }

    if (filtering.searching){
      httpParams = httpParams.append('searching', filtering.searching);
    }

    this.httpClient.get<IProductInfo>(this.baseUrl + 'api/products', {params: httpParams})
      .subscribe(value => {
        this.productsInfoSource.next(value);
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

  getProductsInfoSource(): Observable<IProductInfo>{
    return this.productsInfoSource;
  }

  getProductTypesSource(): Observable<IProductType[]>{
    return this.productTypesSource;
  }

  getBrandsSource(): Observable<IBrand[]>{
    return this.brandsSource;
  }
}
