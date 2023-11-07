<template>
  <div>    
    <div class="card-header" id="menu_series">
        <ul class="nav nav-tabs card-header-tabs">
            <li class="nav-item">
                <router-link class="nav-link"  to="/HomeSeries/">Home Series</router-link>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" data-bs-toggle="dropdown"  role="button" aria-expanded="false">Series</a>
                <ul class="dropdown-menu">
                    <li v-for="serie in series" :key="serie">
                        <router-link class="dropdown-item" :to="'/Series/'+serie.idSerie" >{{ serie.nombre }}</router-link>
                    </li>            
                </ul>
            </li>
            <li class="nav-item">
                <router-link class="nav-link" to="/series/personaje/post">Crear Personaje</router-link>
            </li>
        </ul>
    </div>        
  </div>
</template>
<script>

import ServicesSeries from '../../services/ServicesSeries'
const service = new ServicesSeries();

export default {
    name: 'MenuSeries',
    data(){
        return{
            series : []
        }
    },
    mounted(){

            service.GET_Series()
            .then(response=>{
                this.series = response.data;
            })
            .catch(error=>{
                console.log(error.message); 
            })
    }
}
</script>

<style>

</style>