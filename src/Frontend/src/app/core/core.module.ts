import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavBarComponent} from "./nav-bar/nav-bar.component";
import {RouterLink, RouterLinkActive} from "@angular/router";
import {NgbCollapse, NgbToastModule} from "@ng-bootstrap/ng-bootstrap";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import { NotFoundComponent } from './not-found/not-found.component';
import { ToastsComponent } from './toasts-system/toasts.component';
import { BaseToastComponent } from './toasts-system/base-toast/base-toast.component';
import { WarningToastComponent } from './toasts-system/warning-toast/warning-toast.component';



@NgModule({
  declarations: [
    NavBarComponent,
    NotFoundComponent,
    ToastsComponent,
    BaseToastComponent,
    WarningToastComponent],
  imports: [
    CommonModule,
    RouterLink,
    NgbCollapse,
    FontAwesomeModule,
    RouterLinkActive,
    NgbToastModule
  ],
  exports: [
    NavBarComponent,
    ToastsComponent
  ]
})
export class CoreModule { }
