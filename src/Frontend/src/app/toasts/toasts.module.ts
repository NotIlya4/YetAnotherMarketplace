import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {ToastsComponent} from "./toasts.component";
import {BaseToastComponent} from "./base-toast/base-toast.component";
import {WarningToastComponent} from "./warning-toast/warning-toast.component";
import {NgbToastModule} from "@ng-bootstrap/ng-bootstrap";



@NgModule({
  declarations: [
    ToastsComponent,
    BaseToastComponent,
    WarningToastComponent
  ],
  imports: [
    CommonModule,
    NgbToastModule
  ],
  exports: [
    ToastsComponent
  ]
})
export class ToastsModule { }
