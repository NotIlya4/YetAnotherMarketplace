import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NgbPaginationModule
  ],
  exports: [NgbPaginationModule]
})
export class SharedModule { }
