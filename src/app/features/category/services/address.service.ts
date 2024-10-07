import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Address } from '../models/address.model';

@Injectable({
  providedIn: 'root'
})
export class AddressService {

  constructor(private http: HttpClient) { }

  addAddress( model: Address):Observable<void>{
    
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Address`, model)
    
 }
}
