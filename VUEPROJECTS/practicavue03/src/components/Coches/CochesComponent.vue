<template>
  <div>
    <h1>Coches</h1>
    <table class="table" v-if="coches != null">
        <thead>
            <tr>
                <td v-for="key in Object.keys(coches[0])" :key="key">
                    {{ key.toUpperCase() }}
                </td>
            </tr>
        </thead>
        <tbody> 
            <tr v-for="(coche , index) in coches" :key="coche">
            
            <td v-for="value in Object.values(coche)" :key="value">             
                <img v-if="Object.keys(coche)[index] == 'imagen'" :src=coche.imagen style="{width: 70px; height: 70px;}">
                <span v-else>                    
                    {{ value }}                            
                </span>
            </td>
            </tr>
        </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';
import Globals from './../../Globals'

export default {
    name:'CochesComponent',
    data(){
        return{
            coches : null
        }
    },
    mounted(){
        var request = '/webresources/coches/';

        axios.get(Globals.urlCochesAPI + request).then(response=>{
            this.coches = response.data;
        }).catch(error=>{
            console.log(error.menssage);
        });
    }    
}
</script>

<style>

</style>