import { Injectable } from '@angular/core';
import {IReadonlyBasketItem} from "../models/basket-item";
import { v4 as uuidv4 } from 'uuid';
import {IProduct} from "../models/product";
import {BehaviorSubject, map, Observable, Subject} from "rxjs";
import {ProductsService} from "./products-service/products.service";
import { Basket } from '../models/basket';
import {IBasketTotals} from "../../basket/order-totals/basket-totals";


@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private readonly basket: Basket;
  private readonly basketSource: BehaviorSubject<Basket> = new BehaviorSubject<Basket>(Basket.empty());

  public get totalQuantity$(): Observable<number> {
    return this.basketSource.asObservable().pipe(map(b => {
      return b.items.map(i => i.quantity).reduce((acc, cur) => acc + cur, 0);
    }));
  }

  public get basketItems$(): Observable<ReadonlyArray<IReadonlyBasketItem>> {
    return this.basketSource.asObservable().pipe(map(b => b.items));
  }

  public get basketTotals$(): Observable<IBasketTotals> {
    return this.basketSource.asObservable().pipe(map(b => {
      const subtotal = b.items.map(i => i.product.price * i.quantity).reduce((acc, cur) => acc + cur);
      const shipping = 10;
      const total = subtotal + shipping;
      return {subtotal, shipping, total};
    }));
  }

  constructor() {
    this.basket = this.getBasketFromLocalStorageOrCreateNew();
    this.basketSource.next(this.getBasketFromLocalStorageOrCreateNew());
  }

  public increaseProduct(product: IProduct): void {
    this.basket.increaseProduct(product);
    this.setBasketToLocalStorage(this.basket);
  }

  public decreaseProduct(product: IProduct, amountToDecrease: number = 1): void {
    this.basket.decreaseProduct(product, amountToDecrease);
    this.setBasketToLocalStorage(this.basket);
  }

  public deleteProduct(product: IProduct): void {
    this.basket.deleteProduct(product);
    this.setBasketToLocalStorage(this.basket);
  }

  private setBasketToLocalStorage(basket: Basket): void {
    localStorage.setItem('basket', JSON.stringify(basket));
    this.basketSource.next(this.getBasketFromLocalStorageOrCreateNew());
  }

  private getBasketFromLocalStorageOrCreateNew(): Basket {
    const rawBasket: string | null = localStorage.getItem('basket');

    if (rawBasket === null) {
      const newBasket: Basket = new Basket(uuidv4(), []);
      this.setBasketToLocalStorage(newBasket);
      return newBasket;
    }

    return Basket.fromRaw(rawBasket);
  }
}
