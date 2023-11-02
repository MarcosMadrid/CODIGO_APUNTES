<template>
  <div>
    <h2>Padre Deporte</h2>
    <h3>Favorito {{ favorito }}</h3>
    <ul>
        <li v-for="deporte in deportes" :key="deporte" >
            <hijo-deporte :nombre_deporte="deporte" v-on:Set_Favorito="Set_Favorito"/>
        </li>
    </ul>
  </div>
</template>

<script>
import HijoDeporte from './HijoDeporte.vue'
export default {
  components: { 
        HijoDeporte 
    },
    name: 'PadreComponent',
    data(){
        return{
            deportes : ["tenis","baloncesto", "futbol", "beisbol"],
            favorito : null
        }
    },
    methods : {
        Set_Favorito(deporte){
            this.favorito = deporte;
        }
    }
}
</script>

<style>

</style>