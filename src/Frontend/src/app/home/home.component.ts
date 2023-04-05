import {Component, ViewChild} from '@angular/core';
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  constructor() {
  }

  getImages(): string[] {
    return [1, 2, 3].map<string>(n => `${environment.picturesUrl}home-carousel-00${n}.jpg`);
  }

  images = this.getImages();
}
