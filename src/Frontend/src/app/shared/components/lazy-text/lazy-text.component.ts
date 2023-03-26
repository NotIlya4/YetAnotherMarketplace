import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-lazy-text',
  templateUrl: './lazy-text.component.html',
  styleUrls: ['./lazy-text.component.scss']
})
export class LazyTextComponent {
  @Input() text?: string;
  @Input() placeholderText?: string;
}
