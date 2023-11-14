import {HomeComponent} from './app/Components/home/home.component';
import { NumerodobleComponent } from './app/Components/numerodoble/numerodoble.component';
import { CollatzComponent } from './app/Components/collatz/collatz.component';
import { ListaproductosComponent } from './app/Components/listaproductos/listaproductos.component';
import { DetalleproductoComponent } from './app/Components/detalleproducto/detalleproducto.component';
import { ListascochesComponent } from './app/listascoches/listascoches.component';
import { FormComicComponent } from './app/Components/Comic/form-comic/form-comic.component';
import { ListacomicsComponent } from './app/Components/Comic/listacomics/listacomics.component';

import {Routes, RouterModule} from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { Error404Component } from './app/Components/error404/error404.component';


const appRoutes : Routes =[
    {path: '', component:HomeComponent},
    {path: 'doble', component:NumerodobleComponent},
    {path: 'doble/:numero', component:NumerodobleComponent},
    {path: 'collatz/:numero', component:CollatzComponent},
    {path: 'productos', component:ListaproductosComponent},
    {path: 'producto/:nombre/:imagen/:precio', component:DetalleproductoComponent},
    {path: 'coches', component:ListascochesComponent},
    {path: 'comics', component:ListacomicsComponent},
    {path: 'comics/:comic', component:ListacomicsComponent},
    {path: 'comic/:method', component:FormComicComponent},    
    {path: '**', component:Error404Component}
]

export const appRoutingProvider: any[] = [];
export const routing : ModuleWithProviders<any> =
RouterModule.forRoot(appRoutes)