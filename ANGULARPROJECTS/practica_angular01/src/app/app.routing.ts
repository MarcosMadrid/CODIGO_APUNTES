import {RouterModule, Routes} from '@angular/router'
import { HomeComponent } from './Components/home/home.component'
import { ModuleWithProviders } from '@angular/core';
import { SerieComponent } from './Components/serie/serie.component';
import { PersonajesSeriesComponent } from './Components/personajes-series/personajes-series.component';
import { FormPersonajeComponent } from './Components/form-personaje/form-personaje.component';

const rutas : Routes =[
    {path:'' , component:HomeComponent},
    {path:'serie/:id' , component:SerieComponent},
    {path:'personajes/:id' , component:PersonajesSeriesComponent},    
    {path:'personaje/create' , component:FormPersonajeComponent},    
]

export const appRoutingProvider: any[] = [];
export const routing : ModuleWithProviders<any> = 
RouterModule.forRoot(rutas);
