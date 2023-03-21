import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';


@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent
  ],
  imports: [
    CommonModule,
    NgbPaginationModule
  ],
  exports: [
    NgbPaginationModule,
    PagingHeaderComponent,
    PagerComponent]
})
export class SharedModule { }
