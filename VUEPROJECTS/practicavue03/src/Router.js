import { createRouter, createWebHistory } from "vue-router";
import MenuTabla from './components/MultiplicarParamsUrl/MenuTabla.vue'
import CochesComponent from './components/Coches/CochesComponent.vue'

const Routes=[
    {path:'/tabla_multiplicar/:numero?',component:MenuTabla}
    ,
    {path:'/coches_servicios/',component:CochesComponent}
]

var rutas = createRouter({
    history:createWebHistory(),
    routes:Routes
});

export default rutas;