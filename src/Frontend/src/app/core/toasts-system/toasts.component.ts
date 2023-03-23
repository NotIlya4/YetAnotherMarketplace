import {Component, TemplateRef, ViewChild} from '@angular/core';
import {ToastsService} from "./toasts.service";
import {ToastType} from "./toast-type";

@Component({
  selector: 'app-toasts',
  templateUrl: './toasts.component.html',
  styleUrls: ['./toasts.component.scss']
})
export class ToastsComponent {
  @ViewChild('info') infoTemplate!: TemplateRef<any>;
  @ViewChild('warning') warningTemplate!: TemplateRef<any>;
  @ViewChild('success') successTemplate!: TemplateRef<any>;

  constructor(public toastsService: ToastsService) {
  }

  mapTypeToRef(type: ToastType): TemplateRef<any>{
    if (type == ToastType.Info){
      return this.infoTemplate;
    } else if (type == ToastType.Success) {
      return this.successTemplate;
    } else {
      return this.warningTemplate;
    }
  }
}
