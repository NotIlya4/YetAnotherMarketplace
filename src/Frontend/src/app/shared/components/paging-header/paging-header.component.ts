import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.scss']
})
export class PagingHeaderComponent {
  @Input() currentPage: number = 0;
  @Input() pageSize: number = 0;
  @Input() objectsCount: number = 0;

  getFirstDisplayingNumber(){
    return (this.currentPage - 1) * this.pageSize + 1;
  }

  getLastDisplayingNumber(){
    return Math.min(this.currentPage * this.pageSize, this.objectsCount);
  }
}
