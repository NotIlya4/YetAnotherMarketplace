import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html'
})
export class PagerComponent {
  @Input() totalObjects!: number;
  @Input() pageSize!: number;
  @Output() pageChanged = new EventEmitter<number>();
  private currentPage = 0;
  maxSize = 10;

  onPageChanged(newCurrentPage: number) {
    console.log(`new ${newCurrentPage} old ${this.currentPage}`)
    if (newCurrentPage !== this.currentPage){
      this.pageChanged.emit(newCurrentPage);
      this.currentPage = newCurrentPage;
    }

    // this.pageChanged.emit(newCurrentPage);
    // this.currentPage = newCurrentPage;
  }
}
