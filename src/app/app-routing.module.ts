import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './core/components/homepage/homepage.component';
import { AboutUsComponent } from './features/category/about-us/about-us.component';
import { AddproductComponent } from './features/category/addproduct/addproduct.component';
import { AddressComponent } from './features/category/address/address.component';
import { CartComponent } from './features/category/cart/cart.component';
import { LoginComponent } from './features/category/login/login.component';

import { MenucategorylistnewComponent } from './features/category/menucategorylistnew/menucategorylistnew.component';


import { ProductlistComponent } from './features/category/productlist/productlist.component';
import { SignupComponent } from './features/category/signup/signup.component';
import { NewcartComponent } from './newcart/newcart.component';




const routes: Routes = [
  {
    path:'productlist/:id',
    component:ProductlistComponent
  },
  {
    path:'addproduct',
    component:AddproductComponent
  },
  {
    path:'',
    component:HomepageComponent
  },
  {
    path:'about-us',
    component:AboutUsComponent
  },
   
  {
    path:'menucategorylistnew',
    component:MenucategorylistnewComponent
  },
  {
    path:'cart',
    component:CartComponent
  },
  {
    path:'signup',
    component:SignupComponent
  },
  {
    path:'login',
    component:LoginComponent
  },
  {
    path:'address',
    component:AddressComponent
  },
  {
    path:'newcart',
    component:NewcartComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
