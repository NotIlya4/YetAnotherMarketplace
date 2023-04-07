import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { SearchComponent } from './components/search/search.component';
import {FormsModule} from "@angular/forms";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import {RouterLink} from "@angular/router";
import { TextContentPlaceholderComponent } from './components/placeholders/text-content-placeholder/text-content-placeholder.component';
import {TabComponent} from "./components/tab/tab.component";
import { PrimaryButtonComponent } from './components/primary-button/primary-button.component';
import { TextAutoPlaceholderComponent } from './components/placeholders/text-auto-placeholder/text-auto-placeholder.component';
import { CirclePlaceholderComponent } from './components/placeholders/circle-placeholder/circle-placeholder.component';
import { ShoppingCardIconComponent } from './components/icons/shopping-card-icon/shopping-card-icon.component';
import { LinkComponent } from './components/link/link.component';
import { PlusIconComponent } from './components/icons/plus-icon/plus-icon.component';
import { MinusIconComponent } from './components/icons/minus-icon/minus-icon.component';
import { TrashIconComponent } from './components/icons/trash-icon/trash-icon.component';
import { IncreaseProductsInBasketDirective } from './directives/increase-products-in-basket.directive';
import { DecreaseProductsInBasketDirective } from './directives/decrease-products-in-basket.directive';
import { RemoveProductsInBasketDirective } from './directives/remove-products-in-basket.directive';


@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    SearchComponent,
    TextContentPlaceholderComponent,
    TabComponent,
    PrimaryButtonComponent,
    TextAutoPlaceholderComponent,
    CirclePlaceholderComponent,
    ShoppingCardIconComponent,
    LinkComponent,
    PlusIconComponent,
    MinusIconComponent,
    TrashIconComponent,
    IncreaseProductsInBasketDirective,
    DecreaseProductsInBasketDirective,
    RemoveProductsInBasketDirective
  ],
    imports: [
      CommonModule,
      NgbPaginationModule,
      FormsModule,
      FontAwesomeModule,
      RouterLink,
    ],
  exports: [
    NgbPaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    SearchComponent,
    TextContentPlaceholderComponent,
    TabComponent,
    PrimaryButtonComponent,
    TextAutoPlaceholderComponent,
    CirclePlaceholderComponent,
    ShoppingCardIconComponent,
    LinkComponent,
    PlusIconComponent,
    MinusIconComponent,
    TrashIconComponent,
    IncreaseProductsInBasketDirective,
    DecreaseProductsInBasketDirective,
    RemoveProductsInBasketDirective
  ]
})
export class SharedModule { }
