import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestActionComponent } from './test/test-action/test-action.component';
import { ActionComponent } from './action/action/action.component';

@NgModule({
  declarations: [
    AppComponent,
    TestActionComponent,
    ActionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
