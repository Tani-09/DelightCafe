// import { Component, OnDestroy } from '@angular/core';
// import { Subscription } from 'rxjs';
// import { Signup } from '../models/signup.model';
// import { SignupService } from '../services/signup.service';

// @Component({
//   selector: 'app-signup',
//   templateUrl: './signup.component.html',
//   styleUrls: ['./signup.component.css']
// })
// export class SignupComponent implements OnDestroy{

//   model: Signup;
//   private addSignupSubscription?:Subscription;

//   constructor(private signupService: SignupService){

//     this.model ={
//     customerid:0,
//     firstName: '',
//     lastName: '',
//     email: '',
//     password: '',
//     phoneNo: ''
//     }
//   }

//   onFormSubmit(){
//     this.addSignupSubscription =  this.signupService.addCustomer(this.model)
//       .subscribe({
//        next: (response)=>{
//         console.log('this was successful')
//        }
//       });
//  }

//  ngOnDestroy(): void {
//    this.addSignupSubscription?.unsubscribe();
//  }  

// }



import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Signup } from '../models/signup.model';
import { SignupService } from '../services/signup.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnDestroy {

  model: Signup;
  private addSignupSubscription?: Subscription;

  constructor(private signupService: SignupService, private router: Router) {
    this.model = {
      customerid: 0,
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      phoneNo: ''
    };
  }

  async onFormSubmit() {
    try {
      const result = await this.signupService.addCustomer(this.model).toPromise();
      this.saveDataLocaly(result);
      this.router.navigate(['/login']); // Navigate to the home page
    } catch (error) {
      console.error('Error occurred while registering:', error);
      // Handle error as needed, e.g., display error message to user
    }
  }

  saveDataLocaly(data: any) {
    localStorage.setItem('loginInfo', JSON.stringify(data));
  }

  ngOnDestroy(): void {
    this.addSignupSubscription?.unsubscribe();
  }

}
