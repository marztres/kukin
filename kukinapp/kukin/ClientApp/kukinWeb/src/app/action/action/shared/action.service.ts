import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ActionService {

  constructor(private http: HttpClient) { }


  getRecipeTest() {
    return this.http.get("http://localhost:5000/api/recipe/1");
  }
}
