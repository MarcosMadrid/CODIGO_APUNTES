import { createRouter, createWebHistory } from "vue-router";
import HolaMundoVue from "./components/HolaMundo.vue";
import HomeComponent from "./components/Home.vue";
import HelloWorld from './components/HelloWorld.vue';
import CicloVida from './components/CicloVida.vue';
import MirarNumero from './components/NumeroNegativoPositivo.vue';
import PropiedadConmutada from './components/PropiedadConmutada.vue';
const Rutas=[
    {path:"/",component:HomeComponent}
    ,
    {path:"/HolaMundo",component:HolaMundoVue}
    ,
    {path:"/HelloWorld",component:HelloWorld}
    ,
    {path:"/hooks",component:CicloVida}
    ,
    {path:"/MirarNumero", component:MirarNumero}
    ,
    {path:"/PropiedadConmutada", component:PropiedadConmutada}
];

const router = createRouter({
    history: createWebHistory(),
    routes: Rutas
});

export default router;
