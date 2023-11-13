import {HomeComponent} from './app/Components/home/home.component';
import {CineComponent} from './app/Components/cine/cine.component';
import {MusicaComponent} from './app/Components/musica/musica.component';
import { NumerodobleComponent } from './app/Components/numerodoble/numerodoble.component';
import { CollatzComponent } from './app/Components/collatz/collatz.component';

import {Routes, RouterModule} from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { Error404Component } from './app/Components/error404/error404.component';
import { ListaproductosComponent } from './app/Components/listaproductos/listaproductos.component';
import { DetalleproductoComponent } from './app/Components/detalleproducto/detalleproducto.component';

const appRoutes : Routes =[
    {path: '', component:HomeComponent},
    {path: 'cine', component:CineComponent},
    {path: 'musica', component:MusicaComponent},
    {path: 'doble', component:NumerodobleComponent},
    {path: 'doble/:numero', component:NumerodobleComponent},
    {path: 'collatz/:numero', component:CollatzComponent},
    {path: 'productos', component:ListaproductosComponent},
    {path: 'producto/:nombre/:imagen/:precio', component:DetalleproductoComponent},
    {path: '**', component:Error404Component}
]

export const appRoutingProvider: any[] = [];
export const routing : ModuleWithProviders<any> =
RouterModule.forRoot(appRoutes)