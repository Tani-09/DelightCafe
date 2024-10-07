import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AddProductRequest } from '../models/add-product-request.model';
import { Category } from '../models/category.model';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  addProduct( model: AddProductRequest):Observable<void>{
    
     return this.http.post<void>(`${environment.apiBaseUrl}/api/fooditem`,model)
  }

  getAllProducts():Observable<Product[]>{
      return this.http.get<Product[]>(`${environment.apiBaseUrl}/api/fooditem`)
  }

  GetByCategoryId(catgId:number ):Observable<Product[]>{
    return this.http.get<Product[]>(`${environment.apiBaseUrl}/api/fooditem/getbyCategoryId/${catgId}`)
  }

}
