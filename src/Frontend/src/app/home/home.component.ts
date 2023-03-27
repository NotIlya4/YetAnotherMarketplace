import {Component, ViewChild} from '@angular/core';
import {NgbCarousel, NgbSlideEvent, NgbSlideEventSource} from "@ng-bootstrap/ng-bootstrap";
import {ImagesService} from "../shared/services/images.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  constructor(private imagesService: ImagesService) {
  }

  getImages(): string[] {
    return [1, 2, 3].map<string>(n => this.imagesService.getUrlForImage(`home-carousel-00${n}.jpg`));
  }

  images = this.getImages();
}
