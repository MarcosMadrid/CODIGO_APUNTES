<template>
    <div>
       <h1> Collatz </h1>
       <input placeholder="inserte numero" type="number" v-model="numero">
       <ul  v-html="ComputedCollatz"></ul>
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
                list.push("<li>"+resultado+"</li>");               
            }
            return ("<li>"+resultado+"</li>"); 
        }
    }
}
</script>

<style>

</style>