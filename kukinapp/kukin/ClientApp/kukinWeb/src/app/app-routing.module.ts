import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestActionComponent } from './test/test-action/test-action.component';
import { AppComponent } from './app.component';
import { ActionComponent } from './action/action/action.component';


const routes: Routes = [
  {
    path: '',
    component: ActionComponent,
  }
  ,
  {
    path: 'test',
    component: TestActionComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
