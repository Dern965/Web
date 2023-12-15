import { Component } from '@angular/core';
import { ProductoService } from '../../Services/producto.service';

@Component({
  selector: 'app-productos',
  standalone: true,
  imports: [],
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.scss'
})
export class ProductosComponent {
  lista : DTOProducto[] = [];
  constructor(private pService: ProductoService){
    this.pService.GetProducts().subscribe(result => {
      this.lista = result.products;
    });
  }
}

export interface DTOProducto {
  id: number,
  title: string,
  description: string,
  price: number,
  discountPercentage: number,
  rating: number,
  stock: number,
  brand: string,
  category: string,
  thumbnail: string,
  images: string[]
}