import { Routes, RouterModule } from "@angular/router";
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from "./Components/home/home.component";
import { FormDepartamentoComponent } from "./Components/Departamentos/form-departamento/form-departamento.component";

const rutas : Routes = [
    {path:'',component: HomeComponent},
    {path:'departamento/:method',component: FormDepartamentoComponent},
    {path:'departamento/:method/:departamento',component: FormDepartamentoComponent},
]

export const appRoutingProvider: any[] = [];
export const routing : ModuleWithProviders<any> = 
RouterModule.forRoot(rutas);
