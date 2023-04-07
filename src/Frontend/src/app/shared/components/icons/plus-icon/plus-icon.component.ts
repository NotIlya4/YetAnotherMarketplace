import { Component } from '@angular/core';
import {faCirclePlus} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-plus-icon',
  templateUrl: './plus-icon.component.html',
  styleUrls: ['./plus-icon.component.scss']
})
export class PlusIconComponent {
  plusIcon = faCirclePlus;
}
