import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { CoreModule } from 'src/core/core.module';
import { MealModule } from '../meal/meal.module';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, CoreModule, MealModule],
  template: '<meal-list></meal-list>',
  styles: ['.container {display: none}'],
})
export class HomeComponent {}
