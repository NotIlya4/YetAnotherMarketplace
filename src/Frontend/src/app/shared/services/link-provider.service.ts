import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LinkProviderService {
  get basketLink(): string {
    return 'basket';
  }

  productDetailsLink(productId: string): string {
    return `/shop/${productId}`;
  }
}
