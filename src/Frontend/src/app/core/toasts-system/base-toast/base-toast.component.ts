import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-base-toast',
  templateUrl: './base-toast.component.html',
  styleUrls: ['./base-toast.component.scss']
})
export class BaseToastComponent {
  @Input() detail!: string;
  @Input() classInput: string = '';
  autohide: boolean = true;
}
