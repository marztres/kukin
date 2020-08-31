import { Component, OnInit } from '@angular/core';
import { ActionService } from './shared/action.service';

@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
  styleUrls: ['./action.component.css']
})
export class ActionComponent implements OnInit {
  title = 'kukinWeb';
  data: string[];
  constructor( private recipeService: ActionService ) { }

  ngOnInit(): void {
    const action = this.recipeService.getRecipeTest().subscribe( data => {
      this.data = data as string[];
    });
  }

}
