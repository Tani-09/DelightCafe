import { Component, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { AddProductRequest } from '../models/add-product-request.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.css']
})
export class AddproductComponent implements OnDestroy{

  model: AddProductRequest;
  private addProductSubscription?:Subscription;

  constructor(private productService: ProductService){
    this.model = {
      itemName:'',
      price:'',
      description:'',
      categoryId:''
      
    }
  }
 

  onFormSubmit(){
     this.addProductSubscription =  this.productService.addProduct(this.model)
       .subscribe({
        next: (response)=>{
         console.log('this was successful')
        }
       });
  }

  ngOnDestroy(): void {
    this.addProductSubscription?.unsubscribe();
  }                             

}
