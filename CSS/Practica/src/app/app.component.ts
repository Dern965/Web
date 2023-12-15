import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from './Common/footer/footer.component';
import { HeaderComponent } from './Common/header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductoService } from './Services/producto.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet,FooterComponent,HeaderComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [ProductoService]
})
export class AppComponent {
  title = 'Practica';
}
