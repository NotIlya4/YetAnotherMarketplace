import {IProduct} from "./product";

export interface IBasketItem extends IReadonlyBasketItem {
  product: IProduct
  quantity: number
}

export interface IReadonlyBasketItem{
  readonly product: IProduct
  readonly quantity: number
}
