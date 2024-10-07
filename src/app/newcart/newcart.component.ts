import { Component } from '@angular/core';

@Component({
  selector: 'app-newcart',
  templateUrl: './newcart.component.html',
  styleUrls: ['./newcart.component.css']
})
export class NewcartComponent {
  Cart: boolean = false;
 
  productList: any[] = [];

  constructor(){}
  ngOnInit(): void {
   
    for(let i=0; i<localStorage.length; i++){
      const key = localStorage.key(i);
 
      if(key && key.includes('order_')){
        const value = localStorage.getItem(key);
        const parsedValue = value ? JSON.parse(value) : value;
 
        this.productList?.push(parsedValue);
        console.log(this.productList);
      }
    }
  }


  getTotalPrice(): number{
    let total = 0;
 
    this.productList.forEach(product => total += product.price * product.quantity);
 
    return total;
  }


  onAddProduct(itemId: number): void{
    for(let i=0; i<localStorage.length; i++){
      const key = localStorage.key(i);
 
      if(key && key.includes(`order_${itemId}`)){
        const value = localStorage.getItem(key);
        const parsedValue = value ? JSON.parse(value) : value;
        
          parsedValue.quantity = parsedValue.quantity + 1;
 
        localStorage.setItem(key, JSON.stringify(parsedValue));
      }
    }
    for(let i=0; i<this.productList.length; i++){
      const product = this.productList[i];
 
      if(product.itemId === itemId){
      
        product.quantity = product.quantity + 1;
      }
    }
  }


  onMinusProduct(itemId: number): void{
    for(let i=0; i<localStorage.length; i++){
      const key = localStorage.key(i);
 
      if(key && key.includes(`order_${itemId}`)){
        const value = localStorage.getItem(key);
        const parsedValue = value ? JSON.parse(value) : value;
        if(parsedValue.quantity > 1)
          parsedValue.quantity = parsedValue.quantity - 1;
 
        localStorage.setItem(key, JSON.stringify(parsedValue));
      }
    }
    for(let i=0; i<this.productList.length; i++){
      const product = this.productList[i];
 
      if(product.itemId === itemId){
        if(product.quantity > 1)
        product.quantity = product.quantity - 1;
      }
    }
  }
 
  onRemoveProduct(itemId: number): void{
    for(let i=0; i<localStorage.length; i++){
      const key = localStorage.key(i);
 
      if(key && key.includes(`order_${itemId}`)){
        localStorage.removeItem(key);
      }
    }
    for(let i=0; i<this.productList.length; i++){
      const product = this.productList[i];
 
      if(product.itemId === itemId){
        this.productList = this.productList.filter(b => b !== product);
      }
    }
  }
 
  onRemoveCart(): void{
    for(let i=0; i<localStorage.length; i++){
      const key = localStorage.key(i);
 
      if(key && key.includes(`order_`)){
        localStorage.removeItem(key);
      }
    }
 
    this.productList = [];
  }



}
