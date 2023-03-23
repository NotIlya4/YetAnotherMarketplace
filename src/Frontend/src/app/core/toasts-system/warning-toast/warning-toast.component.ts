import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-warning-toast',
  templateUrl: './warning-toast.component.html',
  styleUrls: ['./warning-toast.component.scss']
})
export class WarningToastComponent {
  @Input() detail!: string;
}
