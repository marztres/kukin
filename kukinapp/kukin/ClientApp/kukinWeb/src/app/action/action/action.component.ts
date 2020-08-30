import { Component, OnInit } from '@angular/core';
import { ActionService } from './shared/action.service';

@Component({
  selector: 'app-action',
  templateUrl: './action.component.html',
  styleUrls: ['./action.component.css']
})
export class ActionComponent implements OnInit {
  title = 'kukinWeb';
  constructor( private recipeService: ActionService ) { }

  ngOnInit(): void {
    const action = this.recipeService.getRecipeTest().subscribe( data => {
      console.log(data);
    });
  }

}
