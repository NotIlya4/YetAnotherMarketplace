import {Component, Input} from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.scss']
})
export class PagingHeaderComponent {
  @Input() currentPage!: number;
  @Input() pageSize!: number;
  @Input() objectsCount?: number;

  getFirstDisplayingNumber(): number | undefined{
    if (!this.isInited()){
      return 0;
    }

    return (this.currentPage - 1) * this.pageSize + 1;
  }

  getLastDisplayingNumber(): number{
    if (!this.isInited()){
      return 0;
    }

    return Math.min(this.currentPage * this.pageSize, this.objectsCount!);
  }

  isInited(): boolean{
    return this.objectsCount !== undefined;
  }
}
