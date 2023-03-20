import {Component, OnInit} from '@angular/core';
import {IProduct} from "../shared/models/product";
import {ShopService} from "./shop.service";
import {IBrand} from "../shared/models/brand";
import {IProductType} from "../shared/models/productType";
import {Observable} from "rxjs";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit{
  products: IProduct[] = [];
  brands: IBrand[] = [];
  productTypes: IProductType[] = [];

  selectedBrand: IBrand = {id: '0', name: 'All'};
  selectedProductType: IProductType = {id: '0', name: 'All'};

  constructor(private shopService: ShopService) {
    shopService.getProductsSource().subscribe(value => {
      this.products = value;
    });
    shopService.getBrandsSource().subscribe(value => {
      this.brands = [{id: '0', name: 'All'}, ...value];
    });
    shopService.getProductTypesSource().subscribe(value => {
      this.productTypes = [{id: '0', name: 'All'}, ...value];
    });
  }

  ngOnInit(){
    this.fetchProducts();
    this.shopService.fetchBrands();
    this.shopService.fetchProductTypes();
  }

  fetchProducts(){
    const productTypeName = this.selectedProductType.name === 'All' ? undefined : this.selectedProductType.name;
    const brandName = this.selectedBrand.name === 'All' ? undefined : this.selectedBrand.name;

    this.shopService.fetchProducts(0, 50, undefined, productTypeName, brandName);
  }

  onBrandSelected(brand: IBrand){
    this.selectedBrand = brand;
    this.fetchProducts();
  }

  onProductTypeSelected(productType: IProductType){
    this.selectedProductType = productType;
    this.fetchProducts();
  }
}
