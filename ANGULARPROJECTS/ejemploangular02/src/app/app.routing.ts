import {Routes, RouterModule} from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './Components/home/home.component';
import { PersonasComponent } from './Components/personas/personas.component';
import { DetallescochesComponent } from './Components/Coches/detallescoches/detallescoches.component';
import { EmpleadosComponent } from './Components/Empleados/empleados/empleados.component';

const appRoutes : Routes =[
    {path: '', component:HomeComponent},
    {path: 'personas', component:PersonasComponent},
    {path: 'coches', component:DetallescochesComponent},
    {path: 'empleados', component:EmpleadosComponent}
]

export const appRoutingProvider: any[] = [];
export const routing : ModuleWithProviders<any> =
RouterModule.forRoot(appRoutes)