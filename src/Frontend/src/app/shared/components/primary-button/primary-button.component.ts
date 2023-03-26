import {Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-primary-button',
  templateUrl: './primary-button.component.html',
  styleUrls: ['./primary-button.component.scss']
})
export class PrimaryButtonComponent {
  @Output() click = new EventEmitter<MouseEvent>();

  onClick($event: MouseEvent){
    this.click.emit($event);
  }
}
