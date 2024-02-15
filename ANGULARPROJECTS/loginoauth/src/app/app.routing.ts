import { Routes, RouterModule } from "@angular/router";
import { ModuleWithProviders } from '@angular/core';
import { LoginComponent } from "./Components/login/login.component";
import { EmpleadosComponent } from "./Components/empleados/empleados.component";

const rutas : Routes = [
    {path:'',component: LoginComponent},
    {path:'empleados/:token',component: EmpleadosComponent}
]

export const appRoutingProvider: any[] = [];
export const routing : ModuleWithProviders<any> = 
RouterModule.forRoot(rutas);
