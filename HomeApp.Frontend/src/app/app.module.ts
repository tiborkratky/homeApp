import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from 'src/core/core.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MealModule } from './meal/meal.module';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, CoreModule, NgbModule, MealModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {
}