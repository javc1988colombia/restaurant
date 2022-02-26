import { Component, OnInit } from '@angular/core';
import {UserService} from "../user.service";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  meals: any[] = [];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getMeals();
  }

  getMeals(): void {
    this.userService.getMeals().subscribe(meals => this.meals = meals);
  }

  reload(): void {
    this.getMeals();
  }

}
