import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-productlist',
  templateUrl: './productlist.component.html',
  styleUrls: ['./productlist.component.css']
})
export class ProductlistComponent implements OnInit {

  // products ?: Product[]
  // cart_length?: number;
  // cart: any[]=[];
  products: Product[] =[]
  productToSave = {
    itemId:0,
    itemName:'',
    price:0,
    imageUrl:'',
    quantity:0
  };

  constructor(private productService: ProductService, private arouter: ActivatedRoute){}


  ngOnInit(): void {
    
    

    this.arouter.paramMap.subscribe(param=>{
     let catgId =  param.get('id')

     this.productService.GetByCategoryId(Number(catgId))
    .subscribe({
      next: (response) =>{this.products = response;}
      })

    }) 
  
  }

  addToCart(id:number){
    for (let i = 0; i < this.products?.length; i++) {
      const product = this.products[i];
      if (product.itemId === id) {
        this.productToSave = {
          itemId: product.itemId,
          itemName: product.itemName,
          price: product.price,
          imageUrl: product.imageUrl,
          quantity: 1
        };
      }
      if(this.productToSave.itemId){
        let key: string = `order_${this.productToSave.itemId}}`;
        localStorage.setItem(key, JSON.stringify(this.productToSave));
      }
    }
  }


  // addToCart(p:Product){
  //   console.log(p);
  //   this.cart.push(p);
  //   localStorage.setItem('cartItems',JSON.stringify(this.cart) ) 
  // }

}
  

  // DisplayLength(productId:string){
  //    return this.cart.filter(x=>x.itemId==Number(productId)).length;
  // }

  // removeFromCart(productId:string):void{

  //   let cartData = localStorage.getItem('cartItems');
  //   let cartDataObj = JSON.parse(cartData??'')
  //   const index:number = cartDataObj.findIndex((prod:Product)=>prod.itemId===productId);
  //   if(index !== -1){
  //     this.cart.splice(index, 1);
  //     localStorage.setItem('cartItems',JSON.stringify(cartDataObj));
  //   }
  // }


