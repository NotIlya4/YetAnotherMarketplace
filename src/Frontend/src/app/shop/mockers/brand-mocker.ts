import {IBrand} from "../../shared/models/brand";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class BrandMocker{
  getBrands(): IBrand[] {
    return [
      {
        id: '1',
        name: 'Google'
      },
      {
        id: '2',
        name: 'Apple'
      },
      {
        id: '3',
        name: 'Reebok'
      }
    ]
  }
}
