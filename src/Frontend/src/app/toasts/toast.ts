import {ToastType} from "./toast-type";

export interface IToast{
  title: string,
  detail: string,
  type: ToastType
}
