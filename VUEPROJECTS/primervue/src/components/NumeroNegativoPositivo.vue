<template>
    <div>
    <input placeholder="Escribe numero" type="number" @input="InpuHandle($event)">
    <hr>
    <ul>
        <li v-for="element in forloop" :key="element">            
            {{ element }}
        </li>
    </ul>
    <p></p>

    <input placeholder="Escribe numero" type="number" v-model="numero2">
    
    <h1 v-if="numero2%2 == 0"> {{ numero2 }} Par</h1>
    <h1 v-else> {{ numero2 }} Impar</h1>
        

  </div>
  
</template>

<script>
export default {
    name: 'MirarNumero',
    data(){
        return{
            numero: 0,
            isPositive : null,
            numero2: null,
            forloop : []
        }
    },
    methods: {
        InpuHandle(e){       
            this.numero = e.target.value;        
            this.ListNumber(this.numero)
        },
        ListNumber(){
            this.forloop = [];
            while(this.numero > 0){
                this.numero = this.numero - 1;
                this.forloop.push(this.numero);
            }
        }
    }

}
</script>

<style>

</style>