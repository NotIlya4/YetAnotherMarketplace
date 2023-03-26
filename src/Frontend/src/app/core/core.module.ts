import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavBarComponent} from "./nav-bar/nav-bar.component";
import {RouterLink, RouterLinkActive} from "@angular/router";
import {NgbCollapse, NgbToastModule} from "@ng-bootstrap/ng-bootstrap";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import { NotFoundComponent } from './not-found/not-found.component';
import { SectionHeaderComponent } from './section-header/section-header.component';
import {BreadcrumbModule} from "xng-breadcrumb";
import {SharedModule} from "../shared/shared.module";


@NgModule({
  declarations: [
    NavBarComponent,
    NotFoundComponent,
    SectionHeaderComponent],
  imports: [
    CommonModule,
    RouterLink,
    NgbCollapse,
    FontAwesomeModule,
    RouterLinkActive,
    NgbToastModule,
    BreadcrumbModule,
    SharedModule
  ],
  exports: [
    NavBarComponent,
    SectionHeaderComponent
  ]
})
export class CoreModule { }
