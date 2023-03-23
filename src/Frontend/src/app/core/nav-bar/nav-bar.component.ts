import {Component, Input} from '@angular/core';
import { faShoppingCart } from "@fortawesome/free-solid-svg-icons";
import {environment} from "../../../environments/environment";

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
  colorMode = "light";
  logoPictureUri = `${environment.picturesUri}logo.png`
}
