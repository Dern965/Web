import { Routes } from '@angular/router';
import { InicioComponent } from './Pages/inicio/inicio.component';
import { ConocenosComponent } from './Pages/conocenos/conocenos.component';
import { UbicanosComponent } from './Pages/ubicanos/ubicanos.component';
import { ProductosComponent } from './Pages/productos/productos.component';

export const routes: Routes = [
    {path: "inicio", component: InicioComponent},
    {path: "conocenos", component: ConocenosComponent},
    {path: "ubicanos", component: UbicanosComponent},
    {path: "productos", component: ProductosComponent},
];
