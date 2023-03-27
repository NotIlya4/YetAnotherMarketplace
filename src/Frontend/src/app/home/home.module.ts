import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import {NgbCarouselModule} from "@ng-bootstrap/ng-bootstrap";



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    NgbCarouselModule
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
