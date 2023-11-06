import { createRouter, createWebHistory } from "vue-router";
import MenuTabla from './components/MultiplicarParamsUrl/MenuTabla.vue';
import CochesComponent from './components/Coches/CochesComponent.vue';
import EmpleadosDetalle from './components/Empleados/EmpleadosDetalle.vue';
import OficiosHome from './components/Empleados/OficiosHome.vue';
import DepartamentosComponent from './components/Departamentos/DepartamentosComponent.vue'
import FormDepartamento from './components/Departamentos/CreateDepartamento.vue'

const Routes=[
    {path:'/tabla_multiplicar/:numero?',component:MenuTabla}
    ,
    {path:'/coches_servicios/',component:CochesComponent}
    ,
    {path:'/EmpleadosDetalle/',component:EmpleadosDetalle}
    ,
    {path:'/OficiosHome/:oficio?',component:OficiosHome}
    ,
    {path:'/Departamentos/',component:DepartamentosComponent}
    ,
    {path:'/FormDepartamento/:type/:id_departamento?',component:FormDepartamento}
]

var rutas = createRouter({
    history:createWebHistory(),
    routes:Routes
});

export default rutas;