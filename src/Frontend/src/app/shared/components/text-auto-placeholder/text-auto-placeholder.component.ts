import {Component, Input} from '@angular/core';
import {PlaceholderWidthSource} from "../text-placeholder/placeholder-width-source";
import {PlaceholderSize} from "../text-placeholder/placeholder-size";

@Component({
  selector: 'app-text-auto-placeholder',
  templateUrl: './text-auto-placeholder.component.html',
  styleUrls: ['./text-auto-placeholder.component.scss']
})
export class TextAutoPlaceholderComponent {
  @Input() placeholderSize: PlaceholderSize = PlaceholderSize.Standard;

  protected readonly PlaceholderWidthSource = PlaceholderWidthSource;
}
