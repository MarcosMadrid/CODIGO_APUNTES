<template>
    <div class="row m-0 p-0">
        <div class="col-6">
            <button @click="Render_Link" class="mt-1 mb-1">Genrar Numero</button>
            <ul class="list-group">
                <router-link class="list-group-item" v-for="numero in numeros" :key="numero" :to="'/tabla_multiplicar/'+numero">
                    {{ numero }}
                </router-link>
            </ul>       
        </div>
        
        <div class="col-5 ">
            <tabla-multiplicar/>
        </div> 
    </div>
</template>

<script>
import TablaMultiplicar from '../MultiplicarParamsUrl/TablaMultiplicar.vue';
export default {
  components: { TablaMultiplicar },
    name: 'MenuTabla',
    data(){
        return{
            numeros:[]
        }
    },
    methods:{
        Render_Link(){
            this.numeros.push(parseInt(Math.random()*100 + 1))
        }
    }
}
</script>

<style>

</style>