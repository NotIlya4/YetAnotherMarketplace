import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import {SharedModule} from "../shared/shared.module";
import { ProductDetailsComponent } from './product-details/product-details.component';
import {RouterModule} from "@angular/router";



@NgModule({
    declarations: [
        ShopComponent,
        ProductItemComponent,
        ProductDetailsComponent
    ],
    exports: [
        ShopComponent
    ],
  imports: [
    CommonModule,
    FontAwesomeModule,
    SharedModule,
    RouterModule
  ]
})
export class ShopModule { }
