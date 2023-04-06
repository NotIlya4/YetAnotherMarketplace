import {Component, Input} from '@angular/core';
import {PlaceholderSize} from "./placeholder-size";

@Component({
  selector: 'app-text-content-placeholder',
  templateUrl: './text-content-placeholder.component.html',
  styleUrls: ['./text-content-placeholder.component.scss']
})
export class TextContentPlaceholderComponent {
  @Input() placeholderSize: PlaceholderSize = PlaceholderSize.Standard;

  getSizeClass(): string {
    if (this.placeholderSize === PlaceholderSize.Big) {
      return 'placeholder-lg';
    }

    if (this.placeholderSize === PlaceholderSize.Small) {
      return 'placeholder-sm';
    }

    return '';
  }

  protected readonly PlaceholderSize = PlaceholderSize;
}
