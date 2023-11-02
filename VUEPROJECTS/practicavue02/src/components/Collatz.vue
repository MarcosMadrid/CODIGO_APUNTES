<template>
    <div>
       <h1> Collatz </h1>
       <input placeholder="inserte numero" type="number" v-model="numero">

       <h3>Con v-html Filter</h3>
       <ul>    
            <li v-for="li in ComputedCollatz" :key="li" v-html="$filters.IsParHTML(li)">
            </li>               
        </ul>
        
        <h3>Con Boolean Filter</h3>
        <ul>
            <li v-for="numero in ComputedCollatz" :key="numero">
                <span v-if="$filters.IsPar(numero)" style="color: green;">
                    {{ numero }}
                </span>
                <span v-else style="color: red">
                    {{ numero }}
                </span>
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name:'CollatzComponent',
    data(){
        return{
            numero: null
        }
    },
    computed : {
        ComputedCollatz(){
            var resultado = this.numero;
            var list = [];
            while(resultado > 1){    
                if(resultado%2 == 0){
                    resultado = resultado/2
                }else{
                    resultado = resultado*3 + 1;
                }        
                list.push(resultado);               
            }
            return (list); 
        }
    }
}
</script>

<style>

</style>