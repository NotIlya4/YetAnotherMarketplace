import { Component } from '@angular/core';
import {BreadcrumbDefinition, BreadcrumbService} from "xng-breadcrumb";

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.scss']
})
export class SectionHeaderComponent {
  breadcrumbs: BreadcrumbDefinition[] = [];

  constructor(private breadcrumbService: BreadcrumbService) {
    breadcrumbService.breadcrumbs$.subscribe(value => {
      this.breadcrumbs = value;
    });
  }
}

