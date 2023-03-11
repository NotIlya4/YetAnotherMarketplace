import {IProductType} from "../../shared/models/productType";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class ProductTypeMocker{
  getProductTypes(): IProductType[]{
    return [
      {
        id: '1',
        name: 'Shoes'
      },
      {
        id: '2',
        name: 'T-Shirt'
      },
      {
        id: '3',
        name: 'Pants'
      },
      {
        id: '4',
        name: 'Watches'
      }
    ]
  }
}
