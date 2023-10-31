import { createRouter, createWebHistory } from "vue-router";
import HomeComponent from "./components/Home.vue";
import CollatzComponent from "./components/Collatz.vue";

const Routes =[
    {path:'/',component:HomeComponent}
    ,
    {path:'/Collatz',component:CollatzComponent},
]

var rutas = createRouter({
    history: createWebHistory(),
    routes : Routes
})

export default rutas;