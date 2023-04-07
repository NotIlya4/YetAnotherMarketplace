import { Component } from '@angular/core';
import {faTrash} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-trash-icon',
  templateUrl: './trash-icon.component.html',
  styleUrls: ['./trash-icon.component.scss']
})
export class TrashIconComponent {
  trashIcon = faTrash;
}
