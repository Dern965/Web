import { Routes } from '@angular/router';
import { InicioComponent } from './Pages/inicio/inicio.component';
import { ConocenosComponent } from './Pages/conocenos/conocenos.component';

export const routes: Routes = [
    {path: "inicio", component: InicioComponent},
    {path: "conocenos", component: ConocenosComponent},
];
