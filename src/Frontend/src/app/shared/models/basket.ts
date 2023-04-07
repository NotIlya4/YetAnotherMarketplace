import {IProduct} from "./product";
import {IBasketItem, IReadonlyBasketItem} from "./basket-item";

export class Basket {
  private _id: string;
  private _items: IBasketItem[];

  public constructor(id: string, items: IBasketItem[]) {
    this._id = id;
    this._items = items;
  }

  public static fromRaw(rawBasket: string): Basket {
    const parsedBasket: any = JSON.parse(rawBasket);
    return new Basket(parsedBasket['_id'], parsedBasket['_items']);
  }

  public static empty(): Basket {
    return new Basket('empty', []);
  }

  public get id(): string {
    return this._id;
  }

  public get items(): ReadonlyArray<IReadonlyBasketItem> {
    return this._items;
  }

  public increaseProduct(product: IProduct, amountToIncrease: number = 1): void {
    const index: number = this.findItemIndex(product);

    if (index !== -1) {
      this._items[index].quantity = this._items[index].quantity + amountToIncrease;
    } else {
      this._items.push({product, quantity: 1});
    }
  }

  public decreaseProduct(product: IProduct, amountToDecrease: number = 1): void {
    const index: number = this.findItemIndex(product);

    if (index !== -1) {
      const quantity: number = this._items[index].quantity;
      if (quantity > 1) {
        this._items[index].quantity = quantity - amountToDecrease;
      } else {
        this.deleteProduct(product);
      }
    }
  }

  public deleteProduct(product: IProduct): void {
    const index: number = this.findItemIndex(product);

    if (index !== -1) {
      this._items.splice(index, 1);
    }
  }

  private findItemIndex(product: IProduct): number {
    return this._items.findIndex(i => i.product.id === product.id);
  }
}
