import {Component} from '@angular/core';
import {Observable, Subject} from "rxjs";
import {BasketService} from "./shared/services/basket.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend';
  cardValue: number = 0;

  constructor(private basketService: BasketService) {
    basketService.totalQuantity$.subscribe(value => this.cardValue = value);
  }
}
