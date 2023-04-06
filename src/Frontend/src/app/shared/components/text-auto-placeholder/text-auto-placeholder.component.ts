import {Component, Input} from '@angular/core';
import {PlaceholderSize} from "../text-content-placeholder/placeholder-size";

@Component({
  selector: 'app-text-auto-placeholder',
  templateUrl: './text-auto-placeholder.component.html',
  styleUrls: ['./text-auto-placeholder.component.scss']
})
export class TextAutoPlaceholderComponent {
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
}
