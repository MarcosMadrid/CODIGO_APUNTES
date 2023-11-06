<template>
  <div>
    <div class="row m-0 p-0">
        <div class="col-6">  
            <ul class="list-group">
                <router-link class="list-group-item" v-for="oficio in oficios" :key="oficio" :to="'/OficiosHome/'+oficio">
                    {{ oficio }}
                </router-link>
            </ul>       
        </div>
        <div class="col-6">
            <oficio-detalles></oficio-detalles>
        </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import Globals from '../../Globals';
import OficioDetalles from './OficioDetalles.vue';
export default {
  components: { OficioDetalles },
    name : 'OficiosHome',
    data(){
        return{
            oficios : []
        }
    },
    mounted(){
        var request = '/api/empleados/oficios';
        axios.get(Globals.urlEmpleadosAPI + request).then(response=>{
            this.oficios = response.data;
        }).catch(error=>{
            console.log(error.menssage);
        })
    }
}
</script>

<style>

</style>