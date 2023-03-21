import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';


@NgModule({
  declarations: [
    PagingHeaderComponent
  ],
  imports: [
    CommonModule,
    NgbPaginationModule
  ],
  exports: [NgbPaginationModule, PagingHeaderComponent]
})
export class SharedModule { }
