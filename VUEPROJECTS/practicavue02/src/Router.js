import { createRouter, createWebHistory } from "vue-router";
import HomeComponent from "./components/Home.vue";
import CollatzComponent from "./components/Collatz.vue";
import TablaMultiplicar from "./components/TablaMultiplicar.vue";
import PadreComponent from './components/PadreDeporte.vue';
import AcumularComponent from './components/AcumuladorComponent.vue';
import ComicsComponent from './components/ComicsComponent.vue'

const Routes =[
    {path:'/',component:HomeComponent}
    ,
    {path:'//Collazt',component:CollatzComponent}
    ,
    {path:'/TablaMultiplicar',component:TablaMultiplicar}
    ,
    {path:'/PadreComponent',component:PadreComponent}
    ,
    {path:'/AcumularComponent',component:AcumularComponent}
    ,
    {path:'/ComicsComponent',component:ComicsComponent}
]

var rutas = createRouter({
    history: createWebHistory(),
    routes : Routes
})

export default rutas;