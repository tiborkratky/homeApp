import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MealListComponent } from './meal-list/meal-list.component';
import { MealRoutingModule } from './meal-routing.module';



@NgModule({
  declarations: [
    MealListComponent
  ],
  imports: [
    CommonModule,
    MealRoutingModule
  ],
  exports: [
    MealListComponent
  ]
})
export class MealModule { }
