import {Component, Input} from '@angular/core';
import {PlaceholderSize} from "./placeholder-size";
import {PlaceholderWidthSource} from "./placeholder-width-source";

@Component({
  selector: 'app-text-placeholder',
  templateUrl: './text-placeholder.component.html',
  styleUrls: ['./text-placeholder.component.scss']
})
export class TextPlaceholderComponent {
  @Input() placeholderSize: PlaceholderSize = PlaceholderSize.Standard;
  @Input() placeholderWidthSource: PlaceholderWidthSource = PlaceholderWidthSource.NgContent;

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
  protected readonly PlaceholderWidthSource = PlaceholderWidthSource;
}
