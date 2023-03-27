import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: [
    './pager.component.scss'
  ]
})
export class PagerComponent {
  currentPage: number = 1;
  maxSize: number = 10;

  @Input() totalObjects!: number;
  @Input() pageSize!: number;

  @Output() pageChanged: EventEmitter<number> = new EventEmitter<number>();

  onPageChanged(newCurrentPage: number) {
    if (newCurrentPage !== this.currentPage){
      this.currentPage = newCurrentPage;
      this.pageChanged.emit(newCurrentPage);
    }
  }
}
