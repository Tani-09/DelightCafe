import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Address } from '../models/address.model';
import { AddressService } from '../services/address.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent {

  model: Address={
    city: '',
    state: '',
    pincode: '',
    streetAddress: '',
    landmark: '',
    userId: 0
  };
  private addAddressSubscription?:Subscription;
  
  constructor(private addressService: AddressService, private router: Router){

    const loginInfo = localStorage.getItem("loginInfo");
    if(loginInfo){
        const customerId = JSON.parse(loginInfo)?.customerid;
        if(customerId){
          this.model.userId = customerId;
        }
    }
   
  }

  onFormSubmit():void{
    this.addAddressSubscription =  this.addressService.addAddress(this.model)
      .subscribe({
       next: (response)=>{
        console.log('this was successful');
        this.router.navigate(['/']);
       },
       error:(error)=>{
        console.error('Error',error);
       }
      });
 }

 placedOrder(){
    if(this.model.userId===0){
      alert("Please Login To Place Order")
      this.router.navigate(['/login']);
      
    }
 }

 ngOnDestroy(): void {
   this.addAddressSubscription?.unsubscribe();
 }  



}
