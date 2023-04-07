import {Component, Input} from '@angular/core';
import { faShoppingCart } from "@fortawesome/free-solid-svg-icons";
import {environment} from "../../../environments/environment";
import {LinkProviderService} from "../../shared/services/link-provider.service";

@Component({
  selector: 'app-nav-bar[cartValue]',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {
  @Input() cartValue: number = 0;
  shoppingCartIcon = faShoppingCart;
  isMenuCollapsed = true;
  mobileModThreshold = "md";
  logoPictureUri = `${environment.picturesUrl}logo.png`

  constructor(public linkProvider: LinkProviderService) {
  }
}
