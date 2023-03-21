import {Component, OnInit} from '@angular/core';
import {IProduct} from "../shared/models/product";
import {ShopService} from "./shop-service/shop.service";
import {IBrand} from "../shared/models/brand";
import {IProductType} from "../shared/models/productType";
import {Observable} from "rxjs";
import {Pagination} from "../shared/models/Pagination";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit{
  productsTotalCount = 1000;
  pageSize = 50;
  currentPage = 1;

  products: IProduct[] = [];
  brands: IBrand[] = [];
  productTypes: IProductType[] = [];

  selectedBrand: IBrand = {id: '0', name: 'All'};
  selectedProductType: IProductType = {id: '0', name: 'All'};
  selectedSorting = '+name';
  sortingsMapping = [
    {name: 'Alphabetical', value: '+name'},
    {name: 'Price Low To High', value: '+price'},
    {name: 'Price High To Low', value: '-price'}
  ];

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

    const pagination: Pagination = Pagination.fromCurrentPagePageSize(this.currentPage, this.pageSize);

    this.shopService.fetchProducts(pagination, [this.selectedSorting], productTypeName, brandName);
  }

  onBrandSelected(brand: IBrand){
    this.selectedBrand = brand;
    this.fetchProducts();
  }

  onProductTypeSelected(productType: IProductType){
    this.selectedProductType = productType;
    this.fetchProducts();
  }

  onSortingChanged(eventTarget: EventTarget | null){
    this.selectedSorting = (eventTarget as HTMLSelectElement).value;
    this.fetchProducts();
  }

  onPageChanged(newPage: number){
    this.currentPage = newPage;
    this.fetchProducts();
  }
}
