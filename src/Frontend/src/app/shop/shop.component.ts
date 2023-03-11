import {Component, OnInit} from '@angular/core';
import {IProduct} from "../shared/models/product";
import {ShopService} from "./shop.service";
import {IBrand} from "../shared/models/brand";
import {IProductType} from "../shared/models/productType";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit{
  products: IProduct[] = [];
  brands: IBrand[] = [];
  productTypes: IProductType[] = [];

  selectedBrand?: IBrand;
  selectedProductType?: IProductType;

  constructor(private shopService: ShopService) {
  }

  ngOnInit(): void {
    this.getProducts()
    this.getBrands()
    this.getProductTypes()
  }

  getProducts(){
    this.shopService.getProducts().subscribe(response => {
      this.products = response;
    })
  }

  getBrands(){
    this.shopService.getBrands().subscribe(response => {
      this.brands = response;
    })
  }

  getProductTypes(){
    this.shopService.getProductTypes().subscribe(response => {
      this.productTypes = response;
    })
  }

  onBrandSelected(brand: IBrand){
    this.selectedBrand = brand;
  }
}
