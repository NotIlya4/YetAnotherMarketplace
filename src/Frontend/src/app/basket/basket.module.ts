import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './basket.component';
import {BasketRoutingModule} from "./basket-routing.module";
import {CoreModule} from "../core/core.module";
import { OrderTotalsComponent } from './order-totals/order-totals.component';
import { BasketSummaryComponent } from './basket-summary/basket-summary.component';
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import {SharedModule} from "../shared/shared.module";



@NgModule({
  declarations: [
    BasketComponent,
    OrderTotalsComponent,
    BasketSummaryComponent
  ],

  imports: [
    CommonModule,
    BasketRoutingModule,
    CoreModule,
    FontAwesomeModule,
    SharedModule
  ]
})
export class BasketModule { }
