import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html'
})
export class PagerComponent {
  @Input() totalObjects: number = 0;
  @Input() pageSize: number = 0;
  @Output() pageChanged = new EventEmitter<number>();
  currentPage = 0;
  maxSize = 10;

  onPageChanged(newCurrentPage: number) {
    this.pageChanged.emit(newCurrentPage);
    this.currentPage = newCurrentPage;
  }
}
