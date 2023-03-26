import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {IBrand} from "../models/brand";

@Injectable({
  providedIn: 'root'
})
export class BrandsService {
  private baseUrl: string = environment.productsUri;

  constructor(private httpClient: HttpClient) {
  }

  get(){
    return this.httpClient.get<IBrand[]>(`${this.baseUrl}brands`);
  }
}
