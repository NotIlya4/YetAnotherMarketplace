import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";



@NgModule({
    declarations: [
        ShopComponent,
        ProductItemComponent
    ],
    exports: [
        ShopComponent
    ],
  imports: [
    CommonModule,
    FontAwesomeModule
  ]
})
export class ShopModule { }
