import { createRouter, createWebHistory } from "vue-router";
import MenuTabla from './components/MultiplicarParamsUrl/MenuTabla.vue';

import EmpleadosDetalle from './components/Empleados/EmpleadosDetalle.vue';
import OficiosHome from './components/Empleados/OficiosHome.vue';
import DepartamentosComponent from './components/Departamentos/DepartamentosComponent.vue';

import CochesComponent from './components/Coches/CochesComponent.vue';
import FormDepartamento from './components/Departamentos/CreateDepartamento.vue';
import FormCoche from './components/Coches/FormCoches.vue';

import AppSeries from './components/Series/AppSeries.vue';
import HomeSeries from './components/Series/SeriesHome.vue';
import SerieDetalles from './components/Series/SerieDetalles.vue';
import FormPersonaje from './components/Series/FormPersonaje.vue';

const Routes=[
    {path:'/tabla_multiplicar/:numero?',component:MenuTabla}
    ,
    {path:'/coches_servicios/',component:CochesComponent}
    ,
    {path:'/coche/:type/:id_coche?',component:FormCoche}
    ,
    {path:'/EmpleadosDetalle/',component:EmpleadosDetalle}
    ,
    {path:'/OficiosHome/:oficio?',component:OficiosHome}
    ,
    {path:'/Departamentos/',component:DepartamentosComponent}
    ,
    {path:'/FormDepartamento/:type/:id_departamento?',component:FormDepartamento}
    ,
    {path:'/HomeSeries/',component:AppSeries , 
        children: [
            {path:'/HomeSeries/', component: HomeSeries}
            ,
            {path:'/Series/:id_serie', component: SerieDetalles}
            ,
            {path:'/Series/Personaje/:method/:id_personaje?', component: FormPersonaje}
        ]
    }
    
    
]

var rutas = createRouter({
    history:createWebHistory(),
    routes:Routes
});

export default rutas;