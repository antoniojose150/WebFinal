import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { CancionForm } from "./cancion";

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }

  postCancionForm(cancionForm: CancionForm): Observable<CancionForm> {
    return of(cancionForm);
  }
}
