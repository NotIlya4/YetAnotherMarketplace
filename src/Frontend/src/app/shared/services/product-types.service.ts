import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {IBrand} from "../models/brand";

@Injectable({
  providedIn: 'root'
})
export class ProductTypesService {
  private baseUrl: string = environment.productsUri;

  constructor(private httpClient: HttpClient) {
  }

  get(){
    return this.httpClient.get<IBrand[]>(`${this.baseUrl}product-types`);
  }
}
