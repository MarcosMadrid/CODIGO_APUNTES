<template>
  <div>
    <div v-if="oficio != null">
        <table class="table" v-if="oficios.length != 0">
        <thead>
            <tr>
                <td v-for="key in Object.keys(oficios[0])" :key="key">
                    {{ key.toUpperCase() }}
                </td>
            </tr>
        </thead>
        <tbody> 
            
            <tr v-for="oficio in oficios" :key="oficio">                             
                <td v-for="value in Object.values(oficio)" :key="value">                        
                    {{ value }}                                            
                </td>
            </tr>
        </tbody>
    </table>
    </div>
  </div>
</template>

<script>
import ServiceEmpleado from './../../services/ServiceEmpleados'

const service = new ServiceEmpleado();

export default {
    name: 'OficioDetalles',
    data(){
        return{
            oficios : [],
            oficio : null
        }
    },    
    mounted(){
        this.oficio = this.$route.params.oficio; 
        service.GET_EmpleadosOficio(this.oficio).then(response=>{
            this.oficios = response
        });       
    },
    watch : {
        '$route.params.oficio'(nextVal, oldVal){
            if (nextVal != oldVal){
                this.oficio = this.$route.params.oficio;       
                service.GET_EmpleadosOficio(this.oficio).then(response=>{
                    this.oficios = response
                });  
            }
        }
    }
}
</script>

<style>

</style>