import { Component } from '@angular/core';
import {faCircleMinus} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-minus-icon',
  templateUrl: './minus-icon.component.html',
  styleUrls: ['./minus-icon.component.scss']
})
export class MinusIconComponent {
  minusIcon = faCircleMinus;
}
