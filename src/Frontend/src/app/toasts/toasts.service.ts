import {Injectable} from '@angular/core';
import {IToast} from "./toast";
import {ToastType} from "./toast-type";

@Injectable({
  providedIn: 'root'
})
export class ToastsService {
  toasts: IToast[] = [];

  warning(title: string, detail: string) {
    this.toasts.push({ title, detail, type: ToastType.Warning });
  }

  info(title: string, detail: string) {
    this.toasts.push({ title, detail, type: ToastType.Info });
  }

  success(title: string, detail: string) {
    this.toasts.push({ title, detail, type: ToastType.Success });
  }

  remove(toast: IToast){
    this.toasts = this.toasts.filter(t => t != toast)
  }
}
