<template>
  <div>
    <h1>TOTAL: {{ total }}</h1>
    <button @click="Render_Acumulador()">Nuevo numero</button>
    <ul>
        <li v-for="(numero,index) in Array(acumuladores)" :key="index">
            <sumar-component v-on:acumular="Acumular"></sumar-component>
        </li>
    </ul>   
  </div>
</template>

<script>
import SumarComponent from './SumarComponent.vue';

export default {
    name:'AcumularComponent',
    components: { SumarComponent },
    data(){
        return{
            total : 0,
            acumuladores : 0
        }
    },
    methods:{
        Acumular(numero){
            this.total += numero
        },
        Render_Acumulador(){
            this.acumuladores += 1
        }
    }
}
</script>

<style>

</style>