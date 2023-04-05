import {Component, OnInit} from '@angular/core';
import {IProduct} from "../shared/models/product";
import {Pagination} from "../shared/models/pagination";
import {IProductsFiltering} from "../shared/services/products-service/products-filtering";
import {ProductsService} from "../shared/services/products-service/products.service";
import {BrandsService} from "../shared/services/brands.service";
import {ProductTypesService} from "../shared/services/product-types.service";
import {PlaceholderSize} from "../shared/components/text-placeholder/placeholder-size";
import {PlaceholderWidthSource} from "../shared/components/text-placeholder/placeholder-width-source";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit{
  products?: IProduct[];
  brandFilters?: string[];
  productTypeFilters?: string[];

  productsTotalCount?: number;
  pageSize: number = 6;
  currentPage = 1;
  productSearch?: string;

  selectedBrand = 'All';
  selectedProductType = 'All';
  selectedSorting = '+name';
  sortingsMapping = [
    {name: 'Alphabetical', value: '+name'},
    {name: 'Price Low To High', value: '+price'},
    {name: 'Price High To Low', value: '-price'}
  ];

  constructor(private productsService: ProductsService, private brandsService: BrandsService, private productTypesService: ProductTypesService) {

  }

  ngOnInit(){
    this.getProducts();
    this.getBrandFilters();
    this.getProductTypeFilters();
  }

  getProducts(){
    const productTypeName: undefined | string = this.selectedProductType === 'All' ? undefined : this.selectedProductType;
    const brandName: undefined | string = this.selectedBrand === 'All' ? undefined : this.selectedBrand;

    const pagination: Pagination = Pagination.fromCurrentPagePageSize(this.currentPage, this.pageSize);

    const filtering: IProductsFiltering = {
      productTypeName,
      brandName,
      searching: this.productSearch
    };

    this.productsService.getProducts(pagination, filtering, [this.selectedSorting])
      .subscribe(value => {
        this.products = value.products;
        this.productsTotalCount = value.total;
      });
  }

  getBrandFilters(){
    this.brandsService.get().subscribe(brands => {
      this.brandFilters = ['All', ...brands.map<string>(b => b.name)];
    })
  }

  getProductTypeFilters(){
    this.productTypesService.get().subscribe(productTypes => {
      this.productTypeFilters = ['All', ...productTypes.map<string>(pt => pt.name)];
    })
  }

  reset(){
    this.currentPage = 1;
    this.products = undefined;
    this.productsTotalCount = undefined;
  }

  onBrandSelected(brand: string){
    this.reset();

    this.selectedBrand = brand;
    this.getProducts();
  }

  onProductTypeSelected(productType: string){
    this.reset();

    this.selectedProductType = productType;
    this.getProducts();
  }

  onSortingChanged(eventTarget: EventTarget | null){
    this.reset();

    this.selectedSorting = (eventTarget as HTMLSelectElement).value;
    this.getProducts();
  }

  onSearchClicked(newProductSearch?: string){
    this.reset();

    this.productSearch = newProductSearch;
    this.getProducts();
  }

  onPageChanged(newPage: number){
    this.products = undefined;

    this.currentPage = newPage;
    this.getProducts();
  }

  protected readonly PlaceholderSize = PlaceholderSize;
  protected readonly PlaceholderWidthSource = PlaceholderWidthSource;
}
