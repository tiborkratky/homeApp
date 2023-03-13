import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MealListComponent } from './meal-list/meal-list.component';

const routes: Routes = [{ path: '', component: MealListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MealRoutingModule {}
