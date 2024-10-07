import { Component, OnInit } from '@angular/core';
import { Category } from '../models/category.model';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-menucategorylistnew',
  templateUrl: './menucategorylistnew.component.html',
  styleUrls: ['./menucategorylistnew.component.css']
})
export class MenucategorylistnewComponent implements OnInit{

  categories: Category[] =[]

  constructor(private categoryService: CategoryService){}

  ngOnInit(): void {
   
  //  let cartData =  localStorage.getItem('cartItems');
  //  console.log(JSON.parse( cartData??''));

    this.categoryService.getAllCategories()
    .subscribe({
      next: (response) =>{
        this.categories = response;
      }
    })

}

}
