import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = "";
  password: string = "";
  // isLoggedIn: boolean = false;

  constructor(
    private router: Router,
    private toastr: ToastrService,
    private loginService: LoginService
  ) {}

  handleSubmit(event: Event): void {
    event.preventDefault();

    if (this.loginService.isLoggedIn) {
      this.toastr.error("Logout first user");
      return;
    }
    if (!this.email && !this.password) return;

    this.loginService.login({email: this.email, password: this.password})
    .subscribe((res)=>{
      this.loginService.isLoggedIn = true;
      this.saveDataLocally(res);
      this.router.navigate(['/']);
      alert("You are now logged in!")
      // window.location.reload();
    },
    (error)=>{
      this.toastr.error(error.message);
      alert("not valid");
    });
    
      
      
  }

  saveDataLocally(data: any): void {
    const result = localStorage.getItem('loginInfo');
    if (result === null) 
    localStorage.setItem("loginInfo", JSON.stringify(data));
  }
}