import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { SearchComponent } from './components/search/search.component';
import {FormsModule} from "@angular/forms";


@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    SearchComponent
  ],
  imports: [
    CommonModule,
    NgbPaginationModule,
    FormsModule
  ],
  exports: [
    NgbPaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    SearchComponent
  ]
})
export class SharedModule { }
