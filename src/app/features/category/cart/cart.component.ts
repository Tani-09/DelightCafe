
import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';
 
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
 
  productss: any;
  cartProducts: any[] = [];
  quantity:number = 0;
  cart: any[]=[];
  products ?: Product[]
  cart_length?: number;

  groupedData:any[] = [];
 
 
  constructor(private productService: ProductService){}
 
 
  ngOnInit(): void{
    let cartData =  localStorage.getItem('cartItems');
    // console.log(JSON.parse( cartData??''));
    let cartDataObj=JSON.parse(cartData??'')
    
    
    this.cartProducts = cartDataObj;
    console.log(`CartProducts: `+this.cartProducts);
    this.DisplayLength();

    this.cart = [...cartDataObj];
    console.log(`Cart: `+this.cart);


    // this.productss = localStorage.getItem('cartItems');
    // // this.products = JSON.parse(this.products ? JSON.parse(this.products) : []);
    // this.products = this.productss.substr(1).slice(0,-1);
    // this.products = this.productss.replace('},', '},,');
    // this.products = this.productss.split(',,');
    // for(let i=0; i<this.productss.length; i++){
    //   this.cartProducts.push(JSON.parse(this.productss[i]));
    // }
    // console.log(this.products);
 
}

groupBy(collection:any[], property:string):any[] {
  var i = 0, val, index,
      values = [], result = [];
  for (; i < collection.length; i++) {
      val = collection[i][property];
      index = values.indexOf(val);
      if (index > -1)
          result[index].push(collection[i]);
      else {
          values.push(val);
          result.push([collection[i]]);
      }
  }
  return result;
}

getTotalPrice():number{
  let total = 0;
  this.cartProducts.forEach(c => total+= c.price);
  return total;
}


addToCart(p:Product){
  console.log(p);
  this.cart.push(p);
  localStorage.setItem('cartItems',JSON.stringify(this.cart) ) 
   this.DisplayLength();

  console.log(this.groupedData);
}

 DisplayLength(){

  // let groupData = this.groupBy(this.cart,"itemId");
  //   console.log(groupData);

  //   groupData.filter(x=>x.)
  this.groupedData = this.groupBy(this.cartProducts, 'itemId');
  }

  removeFromCart(productId:number):void{

    let cartData = localStorage.getItem('cartItems');
    let cartDataObj = JSON.parse(cartData??'')
    const index:number = cartDataObj.findIndex((prod:Product)=>prod.itemId===productId);
    if(index !== -1){
      this.cart.splice(index, 1);
      localStorage.setItem('cartItems',JSON.stringify(cartDataObj));
    }
    this.DisplayLength();
    console.log(this.groupedData);
  }


}
