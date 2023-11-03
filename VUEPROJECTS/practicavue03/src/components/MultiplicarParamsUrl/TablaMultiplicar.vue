<template>
  <div>
    <table class="table" v-if="!isNaN(numero) ">
        <thead>       
        </thead>
        <tbody>
            <tr v-for="(void_e, index) in Array(11)" :key="void_e">
                <td>{{ index }} * {{ numero }}</td>
                <td>{{ index  * numero }}</td>
            </tr>
        </tbody>
    </table>
  </div>
</template>

<script>
export default {
    name:'TablaMultiplicar',
    data(){
        return{
            numero: null
        }
    },
    mounted(){
        this.numero = parseInt(this.$route.params.numero);        
    },
    watch : {
        '$route.params.numero'(nextVal, oldVal){
            if (nextVal != oldVal){
                this.numero = parseInt(this.$route.params.numero);                    
            }
        }
    }
}
</script>

<style>

</style>