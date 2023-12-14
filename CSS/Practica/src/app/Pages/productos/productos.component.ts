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
  lista: DTO_Producto[] = [];
  constructor(private pService: ProductoService){
    pService.GetProductos().subscribe(result => {
      this.lista = result.productos;
    });
  }
}

export interface DTO_Producto {
  id: number,
  nombre: string,
  descripcion: string,
  imagen: string
}