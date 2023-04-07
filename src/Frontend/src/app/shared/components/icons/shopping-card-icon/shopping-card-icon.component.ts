import { Component } from '@angular/core';
import {faShoppingCart} from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-shopping-card-icon',
  templateUrl: './shopping-card-icon.component.html',
  styleUrls: ['./shopping-card-icon.component.scss']
})
export class ShoppingCardIconComponent {
    shoppingCartIcon = faShoppingCart;
}
