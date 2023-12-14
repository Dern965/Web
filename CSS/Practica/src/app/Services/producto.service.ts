import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private http: HttpClient) { }

  public GetProductos(): Observable<any>{
    return this.http.get("https://localhost:7254/ModelProducto");
  }
}
