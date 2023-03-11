import {IProduct} from "../../shared/models/product";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class ProductMocker{
  picturesPath = '../../assets/'

  getMockProducts(): IProduct[]{
    return [
      {
        id: '1',
        name: 'Red T-Shirt',
        description: 'A comfortable and stylish red t-shirt.',
        price: 19.99,
        pictureUrl: `${this.picturesPath}pants-001-500.jpg`,
        productType: 'Clothing',
        productBrand: 'BrandA'
      },
      {
        id: '2',
        name: 'Black Jeans',
        description: 'Slim fit black jeans made with premium denim.',
        price: 79.99,
        pictureUrl: `${this.picturesPath}pants-002-500.jpg`,
        productType: 'Clothing',
        productBrand: 'BrandB'
      },
      {
        id: '3',
        name: 'Leather Wallet',
        description: 'A stylish and durable leather wallet with multiple card slots.',
        price: 49.99,
        pictureUrl: `${this.picturesPath}pants-003-500.jpg`,
        productType: 'Accessories',
        productBrand: 'BrandC'
      },
      {
        id: '4',
        name: 'Wireless Headphones',
        description: 'High-quality wireless headphones with noise-cancelling technology.',
        price: 149.99,
        pictureUrl: `${this.picturesPath}shoes-001-500.jpg`,
        productType: 'Electronics',
        productBrand: 'BrandD'
      },
      {
        id: '5',
        name: 'Fitness Tracker',
        description: 'A sleek and lightweight fitness tracker with heart rate monitor and GPS.',
        price: 99.99,
        pictureUrl: `${this.picturesPath}shoes-002-500.jpg`,
        productType: 'Electronics',
        productBrand: 'BrandE'
      },
      {
        id: '6',
        name: 'Sneakers',
        description: 'Comfortable and stylish sneakers with breathable mesh upper.',
        price: 59.99,
        pictureUrl: `${this.picturesPath}tshirt-001-500.jpg`,
        productType: 'Footwear',
        productBrand: 'BrandF'
      },
      {
        id: '7',
        name: 'Smartwatch',
        description: 'A versatile and feature-packed smartwatch with multiple functions.',
        price: 199.99,
        pictureUrl: `../../assets/tshirt-002-500.jpg`,
        productType: 'Electronics',
        productBrand: 'BrandG'
      },
      {
        id: '8',
        name: 'Sunglasses',
        description: 'Stylish sunglasses with polarized lenses and UV protection.',
        price: 39.99,
        pictureUrl: `${this.picturesPath}tshirt-003-500.jpg`,
        productType: 'Accessories',
        productBrand: 'BrandH'
      },
      {
        id: '9',
        name: 'Backpack',
        description: 'A durable and spacious backpack with multiple compartments.',
        price: 89.99,
        pictureUrl: `${this.picturesPath}watches-001-500.jpg`,
        productType: 'Accessories',
        productBrand: 'BrandI'
      }
    ];
  }
}
