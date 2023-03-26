import {Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  value?: string;
  lastEmittedValue?: string;
  @Output() searchClicked = new EventEmitter<string>();

  onSearchClicked(event: any){
    if (this.lastEmittedValue === this.value){
      return;
    }

    this.searchClicked.emit(this.value ?? '');
  }
}
