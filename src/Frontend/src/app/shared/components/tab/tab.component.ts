import {Component, EventEmitter, Input, Output} from '@angular/core';
import {PlaceholderSize} from "../text-content-placeholder/placeholder-size";

@Component({
  selector: 'app-tab',
  templateUrl: './tab.component.html'
})
export class TabComponent {
  @Input() tabName!: string;

  private _tabs?: string[];
  @Input()
  set tabs(value: string[] | undefined){
    if (value){
      this.selectedTab = value[0];
    }
    this._tabs = value;
  };
  get tabs(): string[] | undefined{
    return this._tabs
  }

  selectedTab?: string;

  @Output() tabSelected = new EventEmitter<string>();

  onTabSelected(filter: string){
    if (filter === this.selectedTab) {
      return;
    }

    this.selectedTab = filter;
    this.tabSelected.emit(filter);
  }

  getPlaceholders(){
    return [0, 1, 1, 1, 1, 1, 1]
  }

  protected readonly PlaceholderSize = PlaceholderSize;
}
