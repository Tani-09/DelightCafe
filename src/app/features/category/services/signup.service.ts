import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Signup } from '../models/signup.model';

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  constructor(private http: HttpClient) { }

  addCustomer( model: Signup):Observable<void>{
    
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Customer`,model)
 }


}
