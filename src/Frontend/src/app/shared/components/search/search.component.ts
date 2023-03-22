import {Component, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent {
  value?: string;
  @Output() searchClicked = new EventEmitter<string | undefined>();

  onSearchClicked(event: any){
    this.searchClicked.emit(this.value);
  }
}
