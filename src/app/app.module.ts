import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { AddproductComponent } from './features/category/addproduct/addproduct.component';
import { ProductlistComponent } from './features/category/productlist/productlist.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http'
import { MatCardModule} from '@angular/material/card'
import { HomepageComponent } from './core/components/homepage/homepage.component';
import { AboutUsComponent } from './features/category/about-us/about-us.component';
import { AdminpageComponent } from './features/category/admin/adminpage/adminpage.component';

import { MenucategorylistnewComponent } from './features/category/menucategorylistnew/menucategorylistnew.component';
import { CartComponent } from './features/category/cart/cart.component';
import { SignupComponent } from './features/category/signup/signup.component';
import { LoginComponent } from './features/category/login/login.component';
import { AddressComponent } from './features/category/address/address.component';
import { ToastrModule} from 'ngx-toastr';
import { NewcartComponent } from './newcart/newcart.component';



 




@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AddproductComponent,
    ProductlistComponent,
    HomepageComponent,
    AboutUsComponent,
    AdminpageComponent,
    MenucategorylistnewComponent,
    CartComponent,
    SignupComponent,
    LoginComponent,
    AddressComponent,
    NewcartComponent,
   
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
    MatCardModule,
    ToastrModule.forRoot()
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
