import {Component, Input, OnInit} from '@angular/core';
import {RandomService} from "../../services/random.service";

@Component({
  selector: 'app-word-placeholder',
  templateUrl: './word-placeholder.component.html'
})
export class WordPlaceholderComponent{
  private minLetters = 8;
  private maxLetters = 22;
  placeholderContent: string;

  constructor(private random: RandomService) {
    const count = random.random(this.minLetters, this.maxLetters);
    let result = '';

    for (let i = 0; i < count; i++) {
      result += 'a';
    }

    this.placeholderContent = result;
  }
}
