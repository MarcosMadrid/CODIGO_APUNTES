<template>
  <div>
    <h2>HOOKS</h2>
    {{ saludo }}
    <button @click="cambiarSaludo()">cambiarSaludo</button> 
    <h1 v-if="mostrar===true">
        HALLOWEEN!!!
    </h1>
  </div>
</template>

<script>
export default {
    name: 'CicloVida',
    data(){
        return{
            saludo: 'Hoy es martes...',
            mostrar: false
        }    
    },

    methods: {
        cambiarSaludo(){
          
            if(this.mostrar === true){
                this.mostrar = false;
                this.saludo = 'Hoy es martes...'
            }else{
                this.mostrar = true;
                this.saludo = "Hoy es Halloween";
            }
        }
    },
    mounted(){

    },
    unmounted(){

    },
    updated(){

    },
    created(){

    }
}
</script>

<style>

</style>